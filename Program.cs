// See https://aka.ms/new-console-template for more information

using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Text;
using System.Text.Json;
using CS_First_HTTP_Client;

ScheduleService scheduleService = new(ApiService.Current);

await ApiService.Current.AuthenticateAsync(new("gracie.zhou@winsor.edu", "&!*428okeKKN"));

var schedule = await scheduleService.GetAcademicSchedule();

foreach (var classes in schedule) {
    Console.WriteLine(classes);
}


//var user = await ApiService.Current.SendAsync<UserInfo>(HttpMethod.Get, "api/users/self");
//var classes= await ApiService.Current.SendAsync<Schedule[]>(HttpMethod.Get, "api/schedule/academics");

/*foreach (var a in classes){
    Console.WriteLine(a);
}
var cycleDays = await ApiService.Current.SendAsync<CycleDay[]>(HttpMethod.Get, "api/schedule/cycle-day");

foreach (var day in cycleDays)
{
    Console.WriteLine($"{day.date:yyyy-M-d dddd} is {day.cycleDay}");
}
*/
