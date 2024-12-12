using BackEnd_Task.Models;
using Core.Dto_s;
using Core.Repositories;
using Core.Services;
using Core.UnitOfWork;
using Microsoft.Extensions.Logging;
using Moq;


namespace UnitTest
{
    public class ProductServiceTests
    {
        private readonly Mock<IProductRepository> _mockRepository;
        private readonly Mock<ICacheService> _mockCacheService;
        private readonly Mock<IUnitOfWork> _mockUnitOfWork;
        private readonly Mock<ILogger<ProductService>> _mockLogger;
        private readonly ProductService _productService;

        public ProductServiceTests()
        {
            _mockRepository = new Mock<IProductRepository>();
            _mockCacheService = new Mock<ICacheService>();
            _mockUnitOfWork = new Mock<IUnitOfWork>();
            _mockLogger = new Mock<ILogger<ProductService>>();
            _productService = new ProductService(
                _mockRepository.Object,
                _mockUnitOfWork.Object,
                _mockCacheService.Object,
                _mockLogger.Object
            );
        }

        [Fact]
        public async Task AddAsync_ReturnsSuccessResponse_WhenProductIsAdded()
        {
            // Arrange
            var product = new Product { Id = 1, Name = "New Product" };
            _mockRepository.Setup(repo => repo.AddAsync(It.IsAny<Product>())).Returns(Task.CompletedTask);
            _mockUnitOfWork.Setup(uow => uow.CommitAsync()).Returns(Task.CompletedTask);

            // Act
            var result = await _productService.AddAsync(product);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(200, result.StatusCode);
            Assert.Equal(product, result.Data);
        }

        [Fact]
        public async Task GetAllAsync_ReturnsSuccessResponse_WithProductList()
        {
            // Arrange
            var products = new List<Product> { new Product { Id = 1, Name = "Test Product" } };
            _mockCacheService.Setup(c => c.GetAsync<IEnumerable<Product>>("products_all")).ReturnsAsync((IEnumerable<Product>)null);
            _mockRepository.Setup(repo => repo.GetAllAsync()).ReturnsAsync(new Response<IEnumerable<Product>> { Data = products });

            // Act
            var result = await _productService.GetAllAsync();

            // Assert
            Assert.NotNull(result);
            Assert.Equal(200, result.StatusCode);
            Assert.Single(result.Data);
        }
    }

}
