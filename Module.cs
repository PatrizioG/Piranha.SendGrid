using Piranha.Extend;

namespace Piranha.Mailer
{
    public class Module : IModule
    {
        public string Author => "Gasperi Patrizio";
        public string Name => "Piranha.SendGrid";
        public string Version => Piranha.Utils.GetAssemblyVersion(GetType().Assembly);
        public string Description => "";
        public string PackageUrl => "";
        public string IconUrl => "";
        public void Init() { }
    }
}
