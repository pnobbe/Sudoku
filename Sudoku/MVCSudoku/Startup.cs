using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MVCSudoku.Startup))]
namespace MVCSudoku
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
