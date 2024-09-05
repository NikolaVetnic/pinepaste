using Microsoft.AspNetCore.Mvc.ModelBinding;
using PinePaste.Application.Pastes.Queries.GetPaste;
using PinePaste.Domain.ValueObjects;

namespace PinePaste.Api.ModelBinders;

public class GetPasteQueryModelBinder : IModelBinder
{
    public Task BindModelAsync(ModelBindingContext bindingContext)
    {
        var valueProviderResult = bindingContext.ValueProvider.GetValue("id");
        if (valueProviderResult == ValueProviderResult.None)
        {
            return Task.CompletedTask;
        }

        var value = valueProviderResult.FirstValue;
        if (PasteId.TryParse(value, out var pasteId))
        {
            bindingContext.Result = ModelBindingResult.Success(new GetPasteQuery(pasteId));
        }
        else
        {
            bindingContext.ModelState.AddModelError("id", "Invalid paste ID format.");
        }

        return Task.CompletedTask;
    }
}