using Framework.API;
using Framework.API.Wrapper;
using Framework.Tests; // To access UserResponse model
using NBomber.CSharp;

namespace Framework.Performance
{
    public class PerformanceEngine
    {
        public static void RunLoadTest()
        {
            // 1. Reuse your existing API implementation
            var apiClient = new RestSharpClient("https://reqres.in");

            // 2. Create the Scenario
            var scenario = Scenario.Create("api_reuse_scenario", async context =>
            {
                try
                {
                    // Directly call your existing framework logic
                    var response = await apiClient.GetAsync<UserResponse>("/api/users/2");

                    // NBomber 6+ expects a Response.Ok() 
                    // You can also pass the response size or data if you want to track it
                    return Response.Ok();
                }
                catch (Exception ex)
                {
                    // If the API throws an error, NBomber logs it as a failure
                    return Response.Fail(message: ex.Message, statusCode: "500");
                }
            })
            .WithWarmUpDuration(TimeSpan.FromSeconds(5))
            .WithLoadSimulations(
                // Simulating 10 users continuously for 30 seconds
                Simulation.KeepConstant(copies: 10, during: TimeSpan.FromSeconds(30))
            );

            // 3. Run and set the Report Folder
            NBomberRunner
                .RegisterScenarios(scenario)
                .WithReportFileName("API_Performance_Report")
                .WithReportFolder("PerformanceReports")
                .Run();
        }
    }
}