using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using NatureShopWeb.Data;
using NatureShopWeb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NatureShopWeb
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<ApplicationDbContext>(option => option.UseInMemoryDatabase(databaseName : "MyDB"));
            services.AddControllersWithViews();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, IServiceProvider serviceProvider)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            var context = serviceProvider.GetService<ApplicationDbContext>();
            AddTestData(context);

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }


        public static void AddTestData(ApplicationDbContext context)
        {
            // Product 1 //
            var product1 = new Product
            {
                ProductId = 1,
                ProductName = "ต้นลั่มซำ",
                ProductType = "ต้นไม้ดอก ไม้ยืนต้น",
                Detail = "ไม้ให้ร่มเงา ไม่ผลัดใบ รากไม่แผ่ใหญ่ ลักษณะเป็นพุ่มสวย เขียวตลอดทั้งปี",
                InStock = true,
                Price = 520,
                Discount = 10,
                Image = "dfce0ac2712e2f29702ebc2a8112945a.jpg",
                BestSeller = 3
            };
            context.Product.Add(product1);
            context.SaveChanges();
            // End Product 1 //

            // Product 2 //
            var product2 = new Product
            {
                ProductId = 2,
                ProductName = "ต้นพวงครามออสเตรเลีย",
                ProductType = "ไม้เลื้อย",
                Detail = "ลักษณะเป็นพุ่มใหญ่ ดอกมีสีม่วงครามหรือม่วงเข้ม ออกดอกตลอดทั้งปี",
                InStock = true,
                Price = 1390,
                Discount = 20,
                Image = "pkgfjhp438907kdkjvop.jpg",
                BestSeller = 5
            };
            context.Product.Add(product2);
            context.SaveChanges();
            // End Product 2 //

            // Product 3 //
            var product3 = new Product
            {
                ProductId = 3,
                ProductName = "ต้นเชอรี่แคระ",
                ProductType = "ไม้ดอก ทรงพุ่ม",
                Detail = "ลักษณะเป็นพุ่มเล็ก ดอกมีสีชมพู ออกดอกและผลบ่อย ดูแลง่าย",
                InStock = true,
                Price = 390,
                Discount = 0,
                Image = "e7542hlp32099dfg54258asw6b.jpg",
                BestSeller = 4
            };
            context.Product.Add(product3);
            context.SaveChanges();
            // End Product 3 //

            // Product 4 //
            var product4 = new Product
            {
                ProductId = 4,
                ProductName = "ต้นแก้วแคระมหามงคล",
                ProductType = "ไม้ดอก ทรงพุ่ม",
                Detail = "ไม้ประดับ ไม้มงคล ดอกเล็กมีกลี่นหอม ออกดอกทั้งปี",
                InStock = true,
                Price = 490,
                Discount = 0,
                Image = "Lfg5645Mfg3256wYrs90.jpg",
                BestSeller = 3
            };
            context.Product.Add(product4);
            context.SaveChanges();
            // End Product 4 //

            // Product 5 //
            var product5 = new Product
            {
                ProductId = 5,
                ProductName = "ต้นมอนสเตร่า ไจแอนท์",
                ProductType = "ต้นไม้ภายในบ้าน",
                Detail = "ใบมีขนาดใหญ่ มีรูฉลุ ชอบความชื้นสูง",
                InStock = true,
                Price = 490,
                Discount = 20,
                Image = "z0q2wi549Fksn846lsaq.jpg",
                BestSeller = 4
            };
            context.Product.Add(product5);
            context.SaveChanges();
            // End Product 5 //

            // Product 6 //
            var product6 = new Product
            {
                ProductId = 6,
                ProductName = "ต้นวาสนา",
                ProductType = "ต้นไม้ภายในบ้าน",
                Detail = "ไม้พุ่ม สูง 5-10 ม. ลำต้นกลม ใบเดี่ยวมีลักษณะเรียวยาวโค้งลงสู้พื้นดิน",
                InStock = true,
                Price = 790,
                Discount = 0,
                Image = "9x7zjm452Ftb47er349aWvb.jpg",
                BestSeller = 5
            };
            context.Product.Add(product6);
            context.SaveChanges();
            // End Product 6 //

        }
    }
}
