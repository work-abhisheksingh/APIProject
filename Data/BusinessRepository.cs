using System.Data;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using MyMvcApiProject.Models;

namespace MyMvcApiProject.Data
{
    public class BusinessRepository : IBusinessRepository
    {
        private readonly string _connectionString;
        private readonly ILogger<BusinessRepository> _logger;

        public BusinessRepository(IConfiguration configuration, ILogger<BusinessRepository> logger)
        {
            _connectionString = configuration.GetConnectionString("DefaultConnection") ?? string.Empty;
            _logger = logger;
        }

        public async Task<BusinessResponse?> GetBusinessByIdAsync(int businessId)
        {
            if (string.IsNullOrWhiteSpace(_connectionString))
            {
                _logger.LogError("Connection string 'DefaultConnection' is not configured.");
                return null;
            }

            await using var connection = new SqlConnection(_connectionString);
            await using var command = new SqlCommand("uspBusiness", connection)
            {
                CommandType = CommandType.StoredProcedure
            };

            command.Parameters.Add(new SqlParameter("@BusinessId", SqlDbType.Int) { Value = businessId });

            try
            {
                await connection.OpenAsync();
                await using var reader = await command.ExecuteReaderAsync(CommandBehavior.SingleRow);
                if (await reader.ReadAsync())
                {
                    var response = new BusinessResponse { BusinessId = businessId };

                    for (int i = 0; i < reader.FieldCount; i++)
                    {
                        string name = reader.GetName(i);
                        object? value = await reader.IsDBNullAsync(i) ? null : reader.GetValue(i);
                        response.Data[name] = value;
                    }

                    return response;
                }

                return null;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error executing uspBusiness for BusinessId {BusinessId}", businessId);
                throw;
            }
        }
    }
}