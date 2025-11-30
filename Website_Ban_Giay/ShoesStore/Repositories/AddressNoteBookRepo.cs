using Microsoft.EntityFrameworkCore;
using ShoesStore.InterfaceRepositories;
using ShoesStore.Models;

namespace ShoesStore.Repositories
{
    public class AddressNoteBookRepo : IAddressNoteBook
    {
        ShoesDbContext context;
        public AddressNoteBookRepo(ShoesDbContext context)
        {
            this.context = context;
        }
        public List<Tinh> GetTinhList()
        {
            return context.Tinhs.ToList();
        }
        public List<Phuong> GetPhuongList(int provinces)
        {
            return context.Phuongs.Where(x=>x.Matinh == provinces).ToList();
        }
       

        public List<Sodiachi> GetAllAddressNote()
        {
            return context.Sodiachis.ToList();
        }
        public int GetMaTinh(string TenTinh)
        {
            return context.Tinhs.FirstOrDefault(x=>x.Tentinh == TenTinh).Matinh;
        }
        public int GetMaPhuong(string Tenphuong)
        {
            return context.Phuongs.FirstOrDefault(x => x.Tenphuong == Tenphuong).Maphuong;
        }
        
        public void AddAddressNote(int proviceId, int districtId, string address,int makh,string tennguoinhan,string sdt)
        {
            Tinh province = context.Tinhs.Find(proviceId);
            Phuong district = context.Phuongs.Find(districtId);
            

            string finalAddress = address + ", "+province.Tentinh + ", "+district.Tenphuong ;

            Sodiachi sdc = new Sodiachi
            {
                Tennguoinhan = tennguoinhan,
                Sdtnguoinhan = sdt,
                Makh = makh,
                Diachi = finalAddress
            };

            context.Sodiachis.Add(sdc);
            context.SaveChanges();
        }
        

        public Sodiachi GetSodiachi(int masodiachi)
        {
            return context.Sodiachis.FirstOrDefault(x => x.Masodiachi == masodiachi);
        }

        public void UpdateSDC(int masdc, string hoten, string sdt, string diachi, int matinh, int maphuong)
        {
            Sodiachi sdc = context.Sodiachis.FirstOrDefault(x => x.Masodiachi == masdc);
            string tentinh = context.Tinhs.FirstOrDefault(x => x.Matinh == matinh).Tentinh;
            string Tenphuong = context.Phuongs.FirstOrDefault(x => x.Maphuong== maphuong).Tenphuong;
            
            string diachiFinal = diachi +", "+tentinh+", "+Tenphuong;

            sdc.Tennguoinhan = hoten;
            sdc.Sdtnguoinhan = sdt;
            sdc.Diachi = diachiFinal;
            context.Sodiachis.Update(sdc);
            context.SaveChanges();
        }

        public void DeleteSDC(int masdc)
        {
            Sodiachi sdc = context.Sodiachis.FirstOrDefault(x => x.Masodiachi == masdc);
            context.Sodiachis.Remove(sdc);
            context.SaveChanges();
        }
    }
}
