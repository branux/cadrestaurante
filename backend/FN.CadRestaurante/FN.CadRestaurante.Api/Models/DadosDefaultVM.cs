using FN.CadRestaurante.Domain.FluentValidator;
using System.Collections.Generic;

namespace FN.CadRestaurante.Api.Models
{
    public class DadosDefaultVM
    {
        public DadosDefaultVM(object result, bool success, IEnumerable<Notification> errors = null)
        {
            Data = result;
            Success = success;
            Errors = errors;
        }

        public object Data { get; set; }
        public bool Success { get; set; }
        public IEnumerable<Notification> Errors { get; set; }
    }
}
