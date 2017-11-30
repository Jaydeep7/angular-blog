using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MVCNotes.Startup))]
namespace MVCNotes
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
