using FluentValidation;
using FluentValidation.Results;
using MediatR;

namespace HouseHoldCart
{
    public class ValidationBehavior<TRequest, TResponse>(IEnumerable<IValidator<TRequest>> validators) : IPipelineBehavior<TRequest, TResponse> where TRequest : notnull
    {
        public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
        {
            var context = new ValidationContext<TRequest>(request);

            if (typeof(TRequest).Name.Contains("Command") && !validators.Any())
            {
                throw new ValidationException("No Validator found for : " + typeof(TRequest).FullName);
            }

            var validationResults = await validators.Select(x => x.ValidateAsync(context, cancellationToken)).AggregateAsync();

            var failures = validationResults.SelectMany(x => x.Errors)
                                            .Where(x => !string.IsNullOrEmpty(x?.ErrorMessage));

            if (failures.Any())
            {
                ThrowException(failures);
            }

            return await next(cancellationToken);
        }

        private static void ThrowException(IEnumerable<ValidationFailure> failures)
        {
            var commandFor = typeof(TRequest).Name
                                .Replace("Create", string.Empty)
                                .Replace("Update", string.Empty)
                                .Replace("Delete", string.Empty)
                                .Replace("Message", string.Empty)
                                .Replace("Add", string.Empty)
                                .Replace("Remove", string.Empty)
                                .Replace("Associate", string.Empty)
                                .Replace("Command", string.Empty);

            throw new ValidationException(string.Format("Error while validating {0}", commandFor), failures);
        }
    }
}
