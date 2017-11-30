using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(TestMVC.Startup))]
namespace TestMVC
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            
        }
    }
}
