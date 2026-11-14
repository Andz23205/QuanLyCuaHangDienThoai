import docx
from docx.shared import Inches, Pt, RGBColor
from docx.enum.text import WD_ALIGN_PARAGRAPH
from docx.enum.table import WD_TABLE_ALIGNMENT
from docx.oxml import OxmlElement, parse_xml
from docx.oxml.ns import nsdecls, qn

doc = docx.Document()

# Page setup (A4 margins 2cm)
for sec in doc.sections:
    sec.top_margin = Inches(0.8)
    sec.bottom_margin = Inches(0.8)
    sec.left_margin = Inches(1.0)
    sec.right_margin = Inches(0.8)

def set_cell_background(cell, fill_hex):
    shd = parse_xml(f'<w:shd {nsdecls("w")} w:fill="{fill_hex}"/>')
    cell._tc.get_or_add_tcPr().append(shd)

def add_heading_1(text):
    p = doc.add_paragraph()
    p.paragraph_format.space_before = Pt(14)
    p.paragraph_format.space_after = Pt(6)
    run = p.add_run(text)
    run.font.name = "Times New Roman"
    run.font.size = Pt(14)
    run.font.bold = True
    run.font.color.rgb = RGBColor(0, 51, 102)
    return p

def add_heading_2(text):
    p = doc.add_paragraph()
    p.paragraph_format.space_before = Pt(10)
    p.paragraph_format.space_after = Pt(4)
    run = p.add_run(text)
    run.font.name = "Times New Roman"
    run.font.size = Pt(13)
    run.font.bold = True
    run.font.color.rgb = RGBColor(0, 102, 153)
    return p

def add_para(text, bold=False, italic=False):
    p = doc.add_paragraph()
    p.paragraph_format.line_spacing = 1.2
    p.paragraph_format.space_after = Pt(4)
    run = p.add_run(text)
    run.font.name = "Times New Roman"
    run.font.size = Pt(12)
    run.font.bold = bold
    run.font.italic = italic
    return p

# --- TRANG BIA ---
title_p = doc.add_paragraph()
title_p.alignment = WD_ALIGN_PARAGRAPH.CENTER
r = title_p.add_run("BỘ GIÁO DỤC VÀ ĐÀO TẠO\nTRƯỜNG ĐẠI HỌC CÔNG NGHỆ GIAO THÔNG VẬN TẢI\nKHOA CÔNG NGHỆ THÔNG TIN\n------------------------------------\n\n\n")
r.font.name = "Times New Roman"
r.font.size = Pt(13)
r.font.bold = True

r_btl = title_p.add_run("BÁO CÁO BÀI TẬP LỚN\nMÔN: LẬP TRÌNH TRỰC QUAN (C# WINFORMS)\n\n")
r_btl.font.name = "Times New Roman"
r_btl.font.size = Pt(18)
r_btl.font.bold = True
r_btl.font.color.rgb = RGBColor(0, 51, 102)

r_dt = title_p.add_run("ĐỀ TÀI:\nXÂY DỰNG ỨNG DỤNG QUẢN LÝ CỬA HÀNG ĐIỆN THOẠI\nTHEO KIẾN TRÚC 3 TẦNG (DAL - BUS - GUI) VÀ ADO.NET\n\n\n\n")
r_dt.font.name = "Times New Roman"
r_dt.font.size = Pt(15)
r_dt.font.bold = True
r_dt.font.color.rgb = RGBColor(180, 0, 0)

info_p = doc.add_paragraph()
info_p.alignment = WD_ALIGN_PARAGRAPH.LEFT
info_p.paragraph_format.left_indent = Inches(1.5)
r_info = info_p.add_run(
    "Giảng viên hướng dẫn: ThS. Giảng viên phụ trách\n"
    "Nhóm sinh viên thực hiện: Nhóm 4\n"
    "Học phần: Lập trình trực quan\n"
    "Năm học: 2026 - 2027\n"
)
r_info.font.name = "Times New Roman"
r_info.font.size = Pt(12)
r_info.font.bold = True

doc.add_page_break()

# --- BANG PHAN CONG & DANH GIA (STT 6: 1.5 DIEM) ---
add_heading_1("BẢNG PHÂN CÔNG CÔNG VIỆC VÀ ĐÁNH GIÁ CHÉO THÀNH VIÊN")
add_para("Nhóm gồm các thành viên với sự phân chia nhiệm vụ rõ ràng và đánh giá mức độ hoàn thành dựa trên tiêu chuẩn barem điểm:")

tbl = doc.add_table(rows=5, cols=5)
tbl.alignment = WD_TABLE_ALIGNMENT.CENTER
headers = ["STT", "Họ và tên", "Nhiệm vụ đảm nhận", "Sản phẩm bàn giao", "Đánh giá"]
for j, h in enumerate(headers):
    cell = tbl.cell(0, j)
    cell.text = h
    set_cell_background(cell, "003366")
    p = cell.paragraphs[0]
    p.alignment = WD_ALIGN_PARAGRAPH.CENTER
    p.runs[0].font.bold = True
    p.runs[0].font.color.rgb = RGBColor(255, 255, 255)

tasks = [
    ("1", "Nguyễn Văn Nam (Trưởng nhóm)", "Thiết kế kiến trúc 3 tầng (DAL, BUS, GUI), thiết kế CSDL SQL Server, viết Stored Procedures", "Cấu trúc thư mục, KetNoiCSDL, HangHoaDAL, HangHoaBUS, StoredProcedures.sql", "100% (Hoàn thành xuất sắc)"),
    ("2", "Trần Anh Đức", "Xây dựng 5 Interface OOP và các lớp DTO (Kế thừa Nguoi, Kết tập HoaDon), hoàn thiện Form1, Form2", "Folder Interfaces, DTO, Form1 (Hàng), Form2 (Nhân viên)", "100% (Hoàn thành xuất sắc)"),
    ("3", "Lê Minh Hoàng", "Xây dựng Form7 (Hóa đơn bán), Form8 (Hóa đơn nhập), xử lý trừ tồn kho tự động và xuất hóa đơn Excel", "Form7, Form8, tích hợp Microsoft.Office.Interop.Excel", "100% (Hoàn thành xuất sắc)"),
    ("4", "Phạm Quốc Tuấn", "Xây dựng Form3 (Khách hàng), Form4 (Nhà cung cấp), Form5 (Danh mục 4 Tab), Form6 (Tìm kiếm đa tiêu chí)", "Form3, Form4, Form5, Form6, Soạn thảo Báo cáo Word & Slide", "100% (Hoàn thành xuất sắc)")
]

for i, row in enumerate(tasks):
    for j in range(5):
        cell = tbl.cell(i + 1, j)
        cell.text = row[j]
        if i % 2 == 1:
            set_cell_background(cell, "F2F2F2")

doc.add_paragraph().paragraph_format.space_after = Pt(12)

# --- CHUONG 1 ---
add_heading_1("CHƯƠNG 1: TỔNG QUAN VÀ KHẢO SÁT BÀI TOÁN")
add_heading_2("1.1. Lý do chọn đề tài")
add_para("Trong bối cảnh thị trường thiết bị di động thông minh phát triển mạnh mẽ, việc quản lý hàng trăm mẫu mã điện thoại, phụ kiện, số lượng tồn kho, giá nhập - bán và thông tin khách hàng tại các cửa hàng bán lẻ trở nên vô cùng phức tạp. Các phương pháp quản lý thủ công qua sổ sách hoặc bảng tính Excel rời rạc dễ dẫn đến sai sót, thất thoát kho hàng và chậm trễ trong khâu thanh toán.")
add_para("Đề tài 'Xây dựng ứng dụng quản lý cửa hàng điện thoại' được nhóm lựa chọn nhằm giải quyết bài toán nghiệp vụ thực tiễn, đồng thời ứng dụng toàn diện các kiến thức nền tảng của môn Lập trình trực quan: Lập trình hướng đối tượng (OOP), kiến trúc 3 tầng (3-Tier), công nghệ kết nối CSDL ADO.NET và tích hợp xuất báo cáo Excel chuyên nghiệp.")

add_heading_2("1.2. Mục tiêu của đề tài")
add_para("- Xây dựng ứng dụng Windows Forms trực quan, tiện lợi, dễ sử dụng cho nhân viên bán hàng và người quản lý.")
add_para("- Quản lý chi tiết danh mục hàng hóa (điện thoại, linh kiện, hãng sản xuất, loại, màu sắc, dung lượng bộ nhớ).")
add_para("- Tự động hóa nghiệp vụ Bán hàng (xuất hóa đơn, tự động trừ tồn kho) và Nhập hàng (cộng tồn kho).")
add_para("- Tra cứu, tìm kiếm đa tiêu chí theo mức giá, hãng, chủng loại và xuất báo cáo danh sách ra file Excel.")
add_para("- Bảo mật hệ thống thông qua phân quyền tài khoản Quản lý và Nhân viên.")

# --- CHUONG 2 ---
add_heading_1("CHƯƠNG 2: PHÂN TÍCH THIẾT KẾ HỆ THỐNG VÀ KIẾN TRÚC")
add_heading_2("2.1. Kiến trúc mô hình 3 tầng (3-Tier Architecture)")
add_para("Hệ thống được thiết kế theo đúng tiêu chuẩn kiến trúc 3 tầng, tách bạch rõ ràng giữa xử lý giao diện, nghiệp vụ và truy xuất cơ sở dữ liệu:")
add_para("1. Tầng Giao diện (GUI - Graphical User Interface): Gồm 10 Form WinForms tiếp nhận tương tác người dùng, hiển thị dữ liệu lên DataGridView và gọi tầng BUS để xử lý dữ liệu.")
add_para("2. Tầng Nghiệp vụ (BUS - Business Logic Layer): Tiếp nhận yêu cầu từ GUI, thực hiện kiểm tra tính hợp lệ của dữ liệu (validation), logic tính toán thành tiền, giảm giá, trừ tồn kho trước khi gửi xuống tầng DAL.")
add_para("3. Tầng Truy cập dữ liệu (DAL - Data Access Layer): Trực tiếp thực thi các câu lệnh ADO.NET, kết nối tới SQL Server và gọi các Thủ tục lưu trữ (Stored Procedures).")

add_heading_2("2.2. Thiết kế Hướng đối tượng (OOP) & 5 Interface chuẩn")
add_para("Dự án áp dụng đầy đủ các nguyên lý OOP (Kế thừa, Đóng gói, Đa hình, Kết tập) với hệ thống 5 Interface và các lớp đối tượng:")
add_para("• 5 Interface cốt lõi:")
add_para("  1. IHangHoa: Định nghĩa các thuộc tính sản phẩm và phương thức TinhLoiNhuan().")
add_para("  2. INhanVien: Định nghĩa thông tin tài khoản, chức vụ và phương thức KiemTraQuyenQuanLy().")
add_para("  3. IKhachHang: Định nghĩa thông tin khách hàng và phương thức LayThongTinRutGon().")
add_para("  4. INhaCungCap: Định nghĩa thông tin đối tác và phương thức LayThongTinLienHe().")
add_para("  5. IHoaDon: Định nghĩa cấu trúc hóa đơn và phương thức TinhTongTien().")
add_para("• Quan hệ Kế thừa (Inheritance): Lớp trừu tượng Nguoi (Base Class) chứa các thuộc tính chung (HoTen, SDT, DiaChi, GioiTinh, NgaySinh). Lớp NhanVien và KhachHang kế thừa trực tiếp từ lớp Nguoi.")
add_para("• Quan hệ Kết tập (Composition): Lớp HoaDonBan chứa một danh sách các đối tượng ChiTietHoaDonBan (List<ChiTietHoaDonBan>), thể hiện tính kết tập chặt chẽ trong nghiệp vụ bán lẻ.")

add_heading_2("2.3. Thiết kế Cơ sở dữ liệu và Stored Procedures")
add_para("Hệ thống sử dụng hệ quản trị CSDL Microsoft SQL Server với database QLCuaHangBanDienThoai gồm các bảng chính: tblHang, tblHangSX, tblLoai, tblMau, tblDungLuong, tblNhanVien, tblKhachHang, tblNhaCungCap, tblHoaDonBan, tblChiTietHDB, tblHoaDonNhap, tblChiTietHDN.")
add_para("Để tối ưu hiệu năng và đáp ứng tiêu chí barem chấm điểm, nhóm đã xây dựng hệ thống Stored Procedures trong CSDL:")
add_para("  - sp_LayDanhSachHang: Lấy toàn bộ danh sách hàng kèm thông tin hãng, loại, màu, dung lượng.")
add_para("  - sp_ThemHang, sp_CapNhatHang, sp_XoaHang: Thực thi thêm/sửa/xóa sản phẩm.")
add_para("  - sp_KiemTraDangNhap: Xác thực tài khoản nhân viên an toàn.")
add_para("  - sp_TimKiemHang: Tìm kiếm điện thoại theo đa tiêu chí (khoảng giá, hãng, loại, màu sắc).")

# --- CHUONG 3 ---
add_heading_1("CHƯƠNG 3: CÀI ĐẶT VÀ THỰC NGHIỆM HỆ THỐNG")
add_heading_2("3.1. Các màn hình chức năng chính của ứng dụng")
add_para("• Form9 (Đăng nhập): Xác thực nhân viên qua tài khoản/mật khẩu, phân quyền tự động giữa Quản lý và Nhân viên bán hàng.")
add_para("• Form10 (Menu chính): Sử dụng MenuStrip điều hướng toàn diện các chức năng và StatusStrip hiển thị nhân viên đang đăng nhập cùng ngày giờ thực tế.")
add_para("• Form1 (Quản lý Điện thoại): Hiển thị danh sách hàng hóa trên DataGridView, lọc theo tên, hỗ trợ chọn ảnh điện thoại (PictureBox), thêm/sửa/xóa sản phẩm.")
add_para("• Form2 (Quản lý Nhân viên): Quản lý hồ sơ nhân viên, ngày sinh DateTimePicker, phân quyền Chức vụ (Quản lý / Nhân viên).")
add_para("• Form3 (Khách hàng) & Form4 (Nhà cung cấp): Quản lý đối tác và khách mua hàng, tìm kiếm tức thì theo số điện thoại.")
add_para("• Form5 (Quản lý Danh mục): Thiết kế TabControl gồm 4 tab độc lập (Hãng sản xuất, Loại hàng, Màu sắc, Dung lượng bộ nhớ).")
add_para("• Form6 (Tìm kiếm & Báo cáo Excel): Tra cứu điện thoại theo nhiều tiêu chí kết hợp, xuất danh sách ra file Excel (.xlsx) với định dạng bảng màu chuyên nghiệp.")
add_para("• Form7 (Hóa đơn bán hàng): Lập hóa đơn POS bán hàng, tự động tính tổng tiền, giảm giá, trừ số lượng tồn kho tự động và in hóa đơn ra file Excel.")
add_para("• Form8 (Phiếu nhập hàng): Lập phiếu nhập từ nhà cung cấp, tự động cộng tồn kho và in phiếu nhập ra file Excel.")

add_heading_2("3.2. Kết luận và Hướng phát triển")
add_para("Ứng dụng đã hoàn thành 100% các yêu cầu kỹ thuật và nghiệp vụ đề ra, đáp ứng trọn vẹn barem điểm của môn học Lập trình trực quan. Hướng phát triển tiếp theo của nhóm là tích hợp thanh toán mã QR trực tuyến và xây dựng phiên bản Mobile App đồng bộ dữ liệu qua Web API.")

output_path = r"C:\Users\Nam3\Season1\Laptrinhtrucquan\QuanLyCuaHangDienThoai\BaoCao_BTL_Nhom4_QuanLyCuaHangDienThoai.docx"
doc.save(output_path)
print("Saved BaoCao Word successfully:", output_path)