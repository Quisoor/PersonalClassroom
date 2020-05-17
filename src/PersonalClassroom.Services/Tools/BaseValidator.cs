using FluentValidation;
using FluentValidation.Results;
using System.Threading;
using System.Threading.Tasks;

namespace PersonalClassroom.Services.Tools
{
    public class BaseValidator<TModel> : AbstractValidator<TModel>
    {
        public const string ON_INSERT = "I";
        public const string ON_UPDATE = "U";
        public const string ON_DELETE = "D";
        public BaseValidator()
        {
            RuleSet(ON_INSERT, OnInsert);
            RuleSet(ON_UPDATE, OnUpdate);
            RuleSet(ON_DELETE, OnDelete);
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
    }
}
