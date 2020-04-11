using Solid.Bootstrapping;
using Solid.Practices.Composition;

namespace BlazorApp1.Client
{
    class Bootstrapper : BootstrapperBase
    {
        public override CompositionOptions CompositionOptions => new CompositionOptions
        {
            Prefixes = new []{"BlazorApp1.Client"}
        };  
    }
}