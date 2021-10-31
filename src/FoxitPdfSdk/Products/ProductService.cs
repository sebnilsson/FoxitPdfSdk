using System.Collections.Generic;
using System.Linq;

namespace FoxitPdfSdk.Products
{
    internal class ProductService : IProductService
    {
        private static readonly List<Product> _products = GetProducts();

        public IReadOnlyList<Product> GetList()
        {
            return _products;
        }

        public Product? GetProduct(long productId)
        {
            return _products.FirstOrDefault(x => x.Id == productId);
        }

        // TODO: Move to a database in a production scenario
        private static List<Product> GetProducts()
        {
            return new List<Product>
            {
                new Product(
                    1,
                    "Motherboard",
                    "The motherboard is the main printed circuit board (PCB) in general-purpose computers and other expandable systems. It holds and allows communication between many of the crucial electronic components of a system, such as the central processing unit (CPU) and memory, and provides connectors for other peripherals.",
                    300,
                    "mb.jpg"),
                new Product(
                    3,
                    "Graphics Processing Unit",
                    "A GPU is a specialized electronic circuit designed to rapidly manipulate and alter memory to accelerate the creation of images in a frame buffer intended for output to a display device. GPUs are used in embedded systems, mobile phones, personal computers, workstations, and game consoles.",
                    500,
                    "gpu.jpg"),
                new Product(
                    5,
                    "Random-access memory",
                    "Random-access memory (RAM) is a form of computer memory that can be read and changed in any order, typically used to store working data and machine code. A random-access memory device allows data items to be read or written in almost the same amount of time irrespective of the physical location of data inside the memory, in contrast with other direct-access data storage media (such as hard disks, CD-RWs, DVD-RWs and the older magnetic tapes and drum memory), where the time required to read and write data items varies significantly depending on their physical locations on the recording medium, due to mechanical limitations such as media rotation speeds and arm movement.",
                    200,
                    "ram.jpg"),
                new Product(
                    10,
                    "Hard disk drive",
                    "A hard disk drive (HDD), hard disk, hard drive, or fixed disk is an electro-mechanical data storage device that stores and retrieves digital data using magnetic storage and one or more rigid rapidly rotating platters coated with magnetic material.",
                    250,
                    "hdd.jpg"),
            };
        }
    }
}