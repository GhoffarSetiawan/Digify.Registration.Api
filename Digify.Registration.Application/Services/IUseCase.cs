using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Digify.Registration.Application.Services
{
    public interface IUseCase<Input,Output>
    {
        Task<Output?> Execute(Input input);
    }
}
