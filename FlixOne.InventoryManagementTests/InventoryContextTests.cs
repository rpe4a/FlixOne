using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FlixOne.InventoryManagement;
using Microsoft.Extensions.DependencyInjection;
using Xunit;

namespace FlixOne.InventoryManagementTests
{
    public class InventoryContextTests
    {
        private readonly ServiceProvider _provider;

        public InventoryContextTests()
        {
            IServiceCollection services = new ServiceCollection();
            services.AddSingleton<IInventoryContext, InventoryContext>();

            _provider = services.BuildServiceProvider();
        }

        [Fact]
        public void MaintainBooks_Successful()
        {
            var context = _provider.GetRequiredService<IInventoryContext>();
            var tasks = new List<Task>();

            // ���������� 30 ����
            foreach (var id in Enumerable.Range(1, 30))
            {
                tasks.Add(AddBook($"Book_{id}"));
            }

            Task.WaitAll(tasks.ToArray());
            tasks.Clear();

            // ������� ���������� ����, ������� 1, 2, 3, 4, 5...
            foreach (var quantity in Enumerable.Range(1, 10))
            {
                foreach (var id in Enumerable.Range(1, 30))
                {
                    tasks.Add(UpdateQuantity($"Book_{id}", quantity));
                }
            }

            foreach (var quantity in Enumerable.Range(1, 10))
            {
                foreach (var id in Enumerable.Range(1, 30))
                {
                    tasks.Add(UpdateQuantity($"Book_{id}", -quantity));
                }
            }

            Task.WaitAll(tasks.ToArray());

            // ��� ���������� ������ ���� 0
            foreach (var book in context.GetBooks())
            {
                Assert.Equal(0, book.Quantity);
            }
        }

        public Task AddBook(string book)
        {
            return Task.Run(() =>
            {
                var context = _provider.GetRequiredService<IInventoryContext>();
                Assert.True(context.AddBook(book));
            });
        }

        public Task UpdateQuantity(string book, int quantity)
        {
            return Task.Run(() =>
            {
                var context = _provider.GetRequiredService<IInventoryContext>();
                Assert.True(context.UpdateQuantity(book, quantity));
            });
        }
    }
}