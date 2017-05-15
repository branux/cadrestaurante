using System;

namespace FN.CadRestaurante.Domain.FluentValidator
{
    public class Notification
    {
        public Notification(string property, string message)
        {
            Id = Guid.NewGuid();
            Property = property;
            Message = message;
        }
        public Guid Id { get; private set; }
        public string Property { get; private set; }
        public string Message { get; private set; }
    }
}
