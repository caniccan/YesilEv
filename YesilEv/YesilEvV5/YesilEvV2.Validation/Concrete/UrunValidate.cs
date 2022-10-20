using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YesilEvV2.DAL;
using YesilEvV2.Validation.Abstract;

namespace YesilEvV2.Validation.Concrete
{
    public class UrunValidate : AbstractUrunValidate<UrunEkleDTO>
    {
        public bool isValid = false;
        public UrunValidate()
        {

        }
        public UrunValidate(UrunEkleDTO urunEkleDTO)
        {
            isValid = UrunEkleValidate(urunEkleDTO);
        }
        public override bool UrunEkleValidate(UrunEkleDTO value)
        {
            if (value.kategoriID==null || value.UreticiID==null || string.IsNullOrEmpty(value.urunAdi) || string.IsNullOrEmpty(value.BarkodNo) || string.IsNullOrEmpty(value.urunIcerik) || string.IsNullOrEmpty(value.OnYuz) || string.IsNullOrEmpty(value.ArkaYuz))
            {
                return false;
            }
            else
            {
                return true;
            }
        }
    }
}
