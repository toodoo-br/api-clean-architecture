using br.com.toodoo.core.Interfaces.Infrastructure;
using br.com.toodoo.service;
using br.com.toodoo.sharedkernel.Interfaces;
using br.com.toodoo.tests.Moks;
using Moq;
using System.Threading.Tasks;
using Xunit;

namespace br.com.toodoo.tests.Services;

public class FieldServiceTest
{
    [Fact]
    public async Task MustAddField()
    {
        //Arrange
        var fieldMock = new Mock<IFieldRepository>();
        var notifier = new Mock<INotifier>();

        fieldMock.Setup(x => x.AddAsync(ModelsMock.FieldMock()));

        var createField = new FieldService(fieldMock.Object, notifier.Object);

        //Action
        var isCreate = await createField.Add(ModelsMock.FieldMock());

        //Assert
        Assert.True(isCreate);

    }
}
