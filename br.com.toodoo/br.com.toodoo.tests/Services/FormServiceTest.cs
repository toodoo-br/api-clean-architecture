using br.com.toodoo.core.Interfaces.Infrastructure;
using br.com.toodoo.service;
using br.com.toodoo.sharedkernel.Interfaces;
using br.com.toodoo.tests.Moks;
using Moq;
using System.Threading.Tasks;
using Xunit;

namespace br.com.toodoo.tests.Services;

public class FormServiceTest
{
    [Fact]
    public async Task MustAddForm()
    {
        //Arrange
        var formMock = new Mock<IFormRepository>();
        var notifier = new Mock<INotifier>();

        formMock.Setup(x => x.AddAsync(ModelsMock.FormMock()));

        var createForm = new FormService(formMock.Object, notifier.Object);

        //Action
        var isCreate = await createForm.Add(ModelsMock.FormMock());

        //Assert
        Assert.True(isCreate);
    }
}
