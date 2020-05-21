using FluentValidation;
using FluentValidation.Results;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace PersonalClassroom.Services.Tools
{
    public class BaseValidator<TModel> : AbstractValidator<TModel>
    {
        public const string ON_INSERT = "I";
        public const string ON_UPDATE = "U";
        public const string ON_DELETE = "D";
        private readonly ErrorService errorService;

        public BaseValidator(ErrorService errorService)
        {
            RuleSet(ON_INSERT, OnInsert);
            RuleSet(ON_UPDATE, OnUpdate);
            RuleSet(ON_DELETE, OnDelete);
            this.errorService = errorService;
        }
        public ValidationResult ValidateInsert(TModel model)
        {
            return this.Validate(model, ruleSet: $"default,{ON_INSERT}");
        }
        public ValidationResult ValidateUpdate(TModel model)
        {
            return this.Validate(model, ruleSet: $"default,{ON_UPDATE}");
        }
        public ValidationResult ValidateDelete(TModel model)
        {
            return this.Validate(model, ruleSet: $"default,{ON_DELETE}");
        }
        public async Task<ValidationResult> ValidateInsertAsync(TModel model, CancellationToken cancellationToken = default)
        {
            return await this.ValidateAsync(model, cancellationToken, ruleSet: $"default,{ON_INSERT}");
        }
        public async Task<ValidationResult> ValidateUpdateAsync(TModel model, CancellationToken cancellationToken = default)
        {
            return await this.ValidateAsync(model, cancellationToken, ruleSet: $"default,{ON_UPDATE}");
        }
        public async Task<ValidationResult> ValidateDeleteAsync(TModel model, CancellationToken cancellationToken = default)
        {
            return await this.ValidateAsync(model, cancellationToken, ruleSet: $"default,{ON_DELETE}");
        }
        public virtual void OnInsert() { }
        public virtual void OnUpdate() { }
        public virtual void OnDelete() { }
        public override ValidationResult Validate(ValidationContext<TModel> context)
        {
            var result = base.Validate(context);
            if (!result.IsValid)
            {
                errorService.AddErrors(result.Errors.ToList()).Wait();
            }
            return result;
        }
        public override async Task<ValidationResult> ValidateAsync(ValidationContext<TModel> context, CancellationToken cancellation = default)
        {
            var result = await base.ValidateAsync(context, cancellation);
            if (!result.IsValid)
            {
                await errorService.AddErrors(result.Errors.ToList());
            }
            return result;
        }
    }
}
