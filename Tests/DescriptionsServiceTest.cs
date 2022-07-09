using Contracts.Repositories;
using Moq;
using Services;
using System;
using System.Threading.Tasks;
using Entities.DataTransferObjects.Description;
using Xunit;


namespace Tests
{
    public class DescriptionsServiceTest
    {
        private readonly DescriptionService _descriptionService;
        private readonly Mock<IRepositoryManager> _repositoryManagerMock = new Mock<IRepositoryManager>();

        public DescriptionsServiceTest()
        {
            _descriptionService = new DescriptionService(_repositoryManagerMock.Object);
        }

        [Fact]
        public async Task GetByIdAsync_ShouldReturnDescription_WhenDescriptionExists()
        {
            //Arrange
            var descriptionId = Guid.NewGuid();
            var descriptionName = "test";
            var descriptionText = "test";
            var descriptionDto = new DescriptionResponse()
            {
                Id = descriptionId,
                Name = descriptionName,
                Text = descriptionText
            };
            _repositoryManagerMock.Setup(x => x.DescriptionRepository.GetDescription(descriptionId))
                .ReturnsAsync(descriptionDto);
            //Act
            var description = await _descriptionService.GetDescription(descriptionId);

            //Assert
            Assert.Equal(descriptionId, description.Id);
        }
    }
}
