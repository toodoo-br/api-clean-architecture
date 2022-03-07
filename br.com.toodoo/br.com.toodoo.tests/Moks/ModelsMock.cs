using br.com.toodoo.core.FieldAggregate;
using br.com.toodoo.core.FormAggregate;
using System;

namespace br.com.toodoo.tests.Moks;

public static class ModelsMock
{
    public static Form FormMock()
    {
        return new Form
        {
            Id = 1,
            Created = DateTime.Now,
            Modified = DateTime.Now,
            CreatedUser = 1,
            ModifiedUser = 1,
            Version = 1,
            Name = "cadPessoa",
            FormCode = "cad123",
            DateVersion = DateTime.Now,
            Active = 1,
            Notes = "cadastro de clientes"
        };
    }

    public static Field FieldMock()
    {
        return new Field
        {
            Id = 1,
            Created = DateTime.Now,
            Modified = DateTime.Now,
            CreatedUser = 1,
            ModifiedUser = 1,
            Name = "dataNascimento",
            Value = "01/01/2000",
            FormId = 1
        };
    }
}
