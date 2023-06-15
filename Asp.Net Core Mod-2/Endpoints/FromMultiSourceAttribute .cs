using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace Asp.Net_Core_Mod_2.Endpoints
{

    public sealed class FromMultiSourceAttribute : Attribute, IBindingSourceMetadata
    {
        public BindingSource BindingSource { get; } = CompositeBindingSource.Create(
            new[] { BindingSource.Path, BindingSource.Query },
            nameof(FromMultiSourceAttribute));
    }
}
