using Common.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DesktopApp.Services
{
    public interface IPlansService
    {
        Task<IEnumerable<Plan>> All();
        Task<Plan> Create(Plan plan);
        Task DeleteOne(int id);
    }
}
