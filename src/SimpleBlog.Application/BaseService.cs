using AutoMapper;
using FluentValidation;
using FluentValidation.Results;
using SimpleBlog.Application.Notifications;
using SimpleBlog.Domain.Common;

namespace SimpleBlog.Application;

public class BaseService(IUnitOfWork unitOfWork, INotifier notifier, IMapper mapper)
{
    protected readonly IUnitOfWork _unitOfWork = unitOfWork;
    protected readonly INotifier _notifier = notifier;
    protected readonly IMapper _mapper = mapper;


    protected void Notify(ValidationResult validationResult)
    {
        foreach (var item in validationResult.Errors)
        {
            Notify(item.ErrorMessage);
        }
    }

    protected void Notify(string message)
    {
        _notifier.Handle(new Notification(message));
    }

    protected async Task<bool> Validate<TValidator, TClass>(TValidator validator, TClass classItem)
        where TValidator : AbstractValidator<TClass>
        where TClass : class
    {
        var validationResult = await validator.ValidateAsync(classItem);

        if (validationResult.IsValid) return true;

        Notify(validationResult);

        return false;
    }

    public async Task<bool> CommitAsync()
    {
        return await _unitOfWork.CommitAsync();
    }
}
