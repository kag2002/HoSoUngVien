using System.Threading.Tasks;
using HoSoUngVien.Models.TokenAuth;
using HoSoUngVien.Web.Controllers;
using Shouldly;
using Xunit;

namespace HoSoUngVien.Web.Tests.Controllers
{
    public class HomeController_Tests: HoSoUngVienWebTestBase
    {
        [Fact]
        public async Task Index_Test()
        {
            await AuthenticateAsync(null, new AuthenticateModel
            {
                UserNameOrEmailAddress = "admin",
                Password = "123qwe"
            });

            //Act
            var response = await GetResponseAsStringAsync(
                GetUrl<HomeController>(nameof(HomeController.Index))
            );

            //Assert
            response.ShouldNotBeNullOrEmpty();
        }
    }
}