using ShoesStore.Models;

namespace ShoesStore.InterfaceRepositories
{
    public interface IAddressNoteBook
    {
        public List<Tinh> GetTinhList();
        public List<Phuong> GetPhuongList(int provinces);
       
        public List<Sodiachi> GetAllAddressNote();
        public void AddAddressNote(int proviceId, int districtId,string address,int makh, string tennguoinhan, string sdt);
        public Sodiachi GetSodiachi(int masodiachi);
        public int GetMaTinh(string TenTinh);
        public int GetMaPhuong(string Tenphuong);
       
        public void UpdateSDC(int masdc, string hoten, string sdt, string diachi, int matinh, int maphuong);
        public void DeleteSDC(int masdc);
    }
}
