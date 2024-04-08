// See https://aka.ms/new-console-template for more information

using System.Text.Json;
using CS_First_HTTP_Client;

HttpClient client = new()
{
    BaseAddress = new Uri("https://forms-dev.winsor.edu");
}
;
var login = new Login("gracie.zhou@winsor.edu, "&!*428okeKKN");

