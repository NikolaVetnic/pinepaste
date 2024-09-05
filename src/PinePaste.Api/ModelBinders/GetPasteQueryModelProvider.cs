using PinePaste.Application.Pastes.Queries.GetPaste;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace PinePaste.Api.ModelBinders;

public class GetPasteQueryModelBinderProvider : IModelBinderProvider
{
    public IModelBinder? GetBinder(ModelBinderProviderContext context)
    {
        return context.Metadata.ModelType == typeof(GetPasteQuery) ? new GetPasteQueryModelBinder() : null;
    }
}