using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(BookATable.Startup))]
namespace BookATable
{
    public partial class Startup {
        public void Configuration(IAppBuilder app) {
            ConfigureAuth(app);
        }
    }
}
