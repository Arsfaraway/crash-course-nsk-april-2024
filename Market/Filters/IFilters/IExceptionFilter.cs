using FluentValidation;
using Market.Exceptions;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Market.Filters.IFilters;

public interface IExceptionFilter
{
    void OnException(ExceptionContext context);

    void HandlerDomainException(DomainException exception, ExceptionContext context);

    void HandlerValidationException(ValidationException validationException, ExceptionContext context);
}