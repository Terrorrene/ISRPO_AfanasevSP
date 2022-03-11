using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace PishiStirai.Entities
{
    public partial class Product
    {
        App.db. 
        public string DiscountText //текст скидки
        {
            get
            {
                if (ProductDiscountAmount == 0 || ProductDiscountAmount == null)
                    return "";
                else
                    return $" Скидка {ProductDiscountAmount}";
            }
        }
        public string TotalCost //итоговая цена
        {
            get
            {
                if (ProductDiscountAmount == 0 || ProductDiscountAmount == null)
                    return $"{ProductCost:N2} рублей";
                else
                    return $"{CostWithDiscount:N2} рублей";

            }
        }
        public decimal CostWithDiscount //цена со скидкой
        {
            get
            {
                if (ProductDiscountAmount == 0 || ProductDiscountAmount == null)
                    return (decimal)ProductCost;
                else
                {
                    var costWithDiscount = ProductCost - ((decimal)ProductDiscountAmount / 100) * ProductCost;
                    return costWithDiscount;
                }
            }
        }
        public Visibility DiscountVisibility //управление отображением скидки
        {
            get
            {
                if (ProductDiscountAmount == 0 || ProductDiscountAmount == null)
                    return Visibility.Collapsed;
                else
                    return Visibility.Visible;
            }
        }
        public string BackColor //выбор цвета со скидкой и без
        {
            get
            {
                if (ProductDiscountAmount > 0)
                    return "#D1FFD1";
                else
                    return "White";
            }
        }
        public string AdminControlVisibility
        {
            get
            {
                if (App.CurrentUser?.UserRole == 2 || App.CurrentUser?.UserRole == 3)
                    return "Visible";
                else
                    return "Collapsed";
            }
        }
    }
}
