import pptx
from pptx import Presentation
from pptx.util import Inches, Pt
from pptx.dml.color import RGBColor
from pptx.enum.text import PP_ALIGN
from pptx.enum.shapes import MSO_SHAPE

prs = Presentation()
prs.slide_width = Inches(13.333)
prs.slide_height = Inches(7.5)
blank_layout = prs.slide_layouts[6]

DARK_BLUE = RGBColor(0, 51, 102)
ACCENT_BLUE = RGBColor(0, 102, 179)
WHITE = RGBColor(255, 255, 255)
LIGHT_GRAY = RGBColor(240, 243, 246)
TEXT_DARK = RGBColor(40, 40, 40)
HIGHLIGHT = RGBColor(220, 53, 69)

def create_header(slide, title_text, subtitle_text=""):
    # Header background banner
    shape = slide.shapes.add_shape(MSO_SHAPE.RECTANGLE, 0, 0, Inches(13.333), Inches(1.2))
    shape.fill.solid()
    shape.fill.fore_color.rgb = DARK_BLUE
    shape.line.fill.background()

    tf = shape.text_frame
    tf.word_wrap = True
    p = tf.paragraphs[0]
    p.text = title_text
    p.font.name = "Arial"
    p.font.size = Pt(28)
    p.font.bold = True
    p.font.color.rgb = WHITE
    p.alignment = PP_ALIGN.LEFT
    tf.margin_left = Inches(0.8)
    tf.margin_top = Inches(0.2)

    if subtitle_text:
        p2 = tf.add_paragraph()
        p2.text = subtitle_text
        p2.font.name = "Arial"
        p2.font.size = Pt(14)
        p2.font.color.rgb = RGBColor(200, 220, 255)

# --- SLIDE 1: TITLE SLIDE ---
s1 = prs.slides.add_slide(blank_layout)
bg1 = s1.shapes.add_shape(MSO_SHAPE.RECTANGLE, 0, 0, Inches(13.333), Inches(7.5))
bg1.fill.solid()
bg1.fill.fore_color.rgb = DARK_BLUE
bg1.line.fill.background()

box1 = s1.shapes.add_textbox(Inches(1.0), Inches(1.5), Inches(11.333), Inches(4.5))
tf1 = box1.text_frame
tf1.word_wrap = True

p = tf1.paragraphs[0]
p.text = "TRƯỜNG ĐẠI HỌC CÔNG NGHỆ GIAO THÔNG VẬN TẢI - KHOA CNTT"
p.font.name = "Arial"
p.font.size = Pt(16)
p.font.color.rgb = RGBColor(200, 220, 255)

p = tf1.add_paragraph()
p.text = "BÁO CÁO BÀI TẬP LỚN MÔN LẬP TRÌNH TRỰC QUAN"
p.font.name = "Arial"
p.font.size = Pt(32)
p.font.bold = True
p.font.color.rgb = WHITE
p.space_before = Pt(20)

p = tf1.add_paragraph()
p.text = "ĐỀ TÀI: QUẢN LÝ CỬA HÀNG ĐIỆN THOẠI"
p.font.name = "Arial"
p.font.size = Pt(26)
p.font.bold = True
p.font.color.rgb = RGBColor(255, 204, 0)
p.space_before = Pt(10)

p = tf1.add_paragraph()
p.text = "Mô hình 3 tầng (DAL - BUS - GUI) | ADO.NET | 5 Interface OOP | Stored Procedures | Xuất Excel"
p.font.name = "Arial"
p.font.size = Pt(16)
p.font.color.rgb = RGBColor(220, 230, 242)
p.space_before = Pt(15)

p = tf1.add_paragraph()
p.text = "Nhóm thực hiện: Nhóm 4 | GVHD: Giảng viên phụ trách môn học"
p.font.name = "Arial"
p.font.size = Pt(16)
p.font.italic = True
p.font.color.rgb = WHITE
p.space_before = Pt(30)

# --- SLIDE 2: MỤC TIÊU & BAREM ĐIỂM (10/10) ---
s2 = prs.slides.add_slide(blank_layout)
create_header(s2, "1. TỔNG QUAN & BAREM ĐÁNH GIÁ ĐẠT ĐIỂM 10/10", "Đáp ứng trọn vẹn toàn bộ tiêu chí chấm điểm của giảng viên")

box2 = s2.shapes.add_textbox(Inches(0.8), Inches(1.6), Inches(11.7), Inches(5.2))
tf2 = box2.text_frame
tf2.word_wrap = True

items_s2 = [
    ("✔ Kiến trúc 3 tầng (1.0đ):", " Phân tách độc lập 3 tầng: DAL (Truy xuất CSDL), BUS (Nghiệp vụ), GUI (Giao diện Forms)."),
    ("✔ Hướng đối tượng OOP (1.5đ):", " Tối thiểu 5 Interface chuẩn + Class kế thừa (Nguoi -> NhanVien, KhachHang) + Kết tập (HoaDonBan chứa ChiTietList)."),
    ("✔ Cơ sở dữ liệu ADO.NET (1.5đ):", " Sử dụng 6 Stored Procedures (1.0đ) + Truy vấn trực tiếp SQL (0.5đ)."),
    ("✔ Chức năng CRUD (2.0đ):", " Thêm, Sửa, Xóa, Tìm kiếm hoàn chỉnh trên toàn bộ 10 Forms."),
    ("✔ Báo cáo & In ấn (1.0đ):", " Xuất hóa đơn bán, phiếu nhập và danh sách sản phẩm ra file Excel (.xlsx) định dạng bảng màu chuyên nghiệp."),
    ("✔ Báo cáo Word & Slide (2.0đ):", " Soạn thảo đầy đủ Báo cáo Word 3 chương theo template và Slide thuyết trình."),
    ("✔ Phân công nhóm (1.5đ):", " Bảng phân chia công việc minh bạch và đánh giá mức độ đóng góp thành viên.")
]

for title, desc in items_s2:
    p = tf2.add_paragraph() if tf2.paragraphs[0].text else tf2.paragraphs[0]
    p.space_after = Pt(8)
    r1 = p.add_run()
    r1.text = title
    r1.font.bold = True
    r1.font.size = Pt(15)
    r1.font.color.rgb = DARK_BLUE
    r2 = p.add_run()
    r2.text = desc
    r2.font.size = Pt(15)
    r2.font.color.rgb = TEXT_DARK

# --- SLIDE 3: KIẾN TRÚC 3 TẦNG (DAL - BUS - GUI) ---
s3 = prs.slides.add_slide(blank_layout)
create_header(s3, "2. KIẾN TRÚC MÔ HÌNH 3 TẦNG (3-TIER ARCHITECTURE)", "Tách bạch rõ ràng trách nhiệm giữa Giao diện, Nghiệp vụ và Dữ liệu")

# 3 Columns for 3 tiers
tiers = [
    ("GUI (TẦNG GIAO DIỆN)", "Gồm 10 Windows Forms tương tác với người dùng:\n• Form9: Đăng nhập & phân quyền\n• Form10: Menu điều hướng chính\n• Form1 - Form5: Quản lý danh mục\n• Form6: Tìm kiếm & Báo cáo Excel\n• Form7 - Form8: Bán hàng & Nhập kho\n\n* Không viết lệnh SQL trong Form, chỉ gọi qua tầng BUS!"),
    ("BUS (TẦNG NGHIỆP VỤ)", "Xử lý logic, kiểm tra tính hợp lệ dữ liệu:\n• HangHoaBUS: Kiểm tra mã, giá, tồn kho\n• NhanVienBUS: Kiểm tra đăng nhập, SĐT\n• KhachHangBUS & NhaCungCapBUS\n• Tính toán thành tiền, giảm giá\n\n* Là cầu nối trung gian giữa GUI và DAL."),
    ("DAL (TẦNG TRUY XUẤT CSDL)", "Giao tiếp trực tiếp với Microsoft SQL Server:\n• DatabaseAccess: Quản lý SqlConnection\n• HangHoaDAL: Gọi Stored Procedures\n• NhanVienDAL, KhachHangDAL, NhaCungCapDAL\n\n* Hỗ trợ cả Stored Procedure và Query trực tiếp.")
]

left_positions = [Inches(0.8), Inches(4.8), Inches(8.8)]
for idx, (title, content) in enumerate(tiers):
    card = s3.shapes.add_shape(MSO_SHAPE.ROUNDED_RECTANGLE, left_positions[idx], Inches(1.6), Inches(3.7), Inches(5.2))
    card.fill.solid()
    card.fill.fore_color.rgb = LIGHT_GRAY
    card.line.color.rgb = ACCENT_BLUE
    card.line.width = Pt(1.5)

    tf = card.text_frame
    tf.word_wrap = True
    p = tf.paragraphs[0]
    p.text = title
    p.font.name = "Arial"
    p.font.size = Pt(16)
    p.font.bold = True
    p.font.color.rgb = DARK_BLUE
    p.alignment = PP_ALIGN.CENTER
    p.space_after = Pt(12)

    p_body = tf.add_paragraph()
    p_body.text = content
    p_body.font.name = "Arial"
    p_body.font.size = Pt(13)
    p_body.font.color.rgb = TEXT_DARK

# --- SLIDE 4: THIẾT KẾ HƯỚNG ĐỐI TƯỢNG (OOP) ---
s4 = prs.slides.add_slide(blank_layout)
create_header(s4, "3. THIẾT KẾ HƯỚNG ĐỐI TƯỢNG (5 INTERFACE + KẾ THỪA + KẾT TẬP)", "Đạt tối đa 1.5 điểm tiêu chí OOP trong barem chấm điểm")

box4_l = s4.shapes.add_textbox(Inches(0.8), Inches(1.6), Inches(5.6), Inches(5.2))
tf4_l = box4_l.text_frame
tf4_l.word_wrap = True

p = tf4_l.paragraphs[0]
p.text = "HỆ THỐNG 5 INTERFACE CHUẨN:"
p.font.bold = True
p.font.size = Pt(18)
p.font.color.rgb = DARK_BLUE
p.space_after = Pt(10)

ifs = [
    ("1. IHangHoa:", " Quy định thuộc tính SP và phương thức TinhLoiNhuan()"),
    ("2. INhanVien:", " Quy định thông tin tài khoản và KiemTraQuyenQuanLy()"),
    ("3. IKhachHang:", " Quy định thông tin KH và LayThongTinRutGon()"),
    ("4. INhaCungCap:", " Quy định đối tác và LayThongTinLienHe()"),
    ("5. IHoaDon:", " Quy định cấu trúc HĐ và phương thức TinhTongTien()")
]
for name, desc in ifs:
    p = tf4_l.add_paragraph()
    p.space_after = Pt(6)
    r1 = p.add_run()
    r1.text = name + " "
    r1.font.bold = True
    r1.font.size = Pt(14)
    r1.font.color.rgb = ACCENT_BLUE
    r2 = p.add_run()
    r2.text = desc
    r2.font.size = Pt(13)

box4_r = s4.shapes.add_textbox(Inches(6.8), Inches(1.6), Inches(5.7), Inches(5.2))
tf4_r = box4_r.text_frame
tf4_r.word_wrap = True

p = tf4_r.paragraphs[0]
p.text = "TÍNH KẾ THỪA & KẾT TẬP TRONG DỰ ÁN:"
p.font.bold = True
p.font.size = Pt(18)
p.font.color.rgb = DARK_BLUE
p.space_after = Pt(10)

oops = [
    ("• Tính Kế thừa (Inheritance):", " Xây dựng lớp trừu tượng Nguoi (Base Class) chứa các thuộc tính chung: HoTen, SDT, DiaChi, GioiTinh, NgaySinh. Lớp NhanVien và KhachHang kế thừa trực tiếp từ lớp Nguoi."),
    ("• Triển khai Interface (Polymorphism):", " Mỗi Class DTO đều implements Interface tương ứng, hiện thực hóa các phương thức hợp đồng."),
    ("• Tính Kết tập (Composition):", " Lớp HoaDonBan chứa một danh sách các đối tượng ChiTietHoaDonBan (List<ChiTietHoaDonBan>), thể hiện quan hệ một hóa đơn gồm nhiều dòng sản phẩm.")
]
for name, desc in oops:
    p = tf4_r.add_paragraph()
    p.space_after = Pt(8)
    r1 = p.add_run()
    r1.text = name
    r1.font.bold = True
    r1.font.size = Pt(14)
    r1.font.color.rgb = HIGHLIGHT
    r2 = p.add_run()
    r2.text = desc
    r2.font.size = Pt(13)

# --- SLIDE 5: STORED PROCEDURES & CSDL ---
s5 = prs.slides.add_slide(blank_layout)
create_header(s5, "4. CƠ SỞ DỮ LIỆU & TRUY VẤN BẰNG THỦ TỤC (STORED PROCEDURES)", "Đạt trọn vẹn 1.5 điểm tiêu chí CSDL (1.0đ Thủ tục + 0.5đ Truy vấn trực tiếp)")

box5 = s5.shapes.add_textbox(Inches(0.8), Inches(1.6), Inches(11.7), Inches(5.2))
tf5 = box5.text_frame
tf5.word_wrap = True

sps = [
    ("1. sp_LayDanhSachHang:", " Truy vấn toàn bộ mặt hàng điện thoại, tự động liên kết (LEFT JOIN) 4 bảng phụ (Hãng SX, Loại, Màu, Dung lượng) để lấy tên hiển thị rõ ràng."),
    ("2. sp_ThemHang:", " Tiếp nhận các tham số @MaHang, @TenHang, @DonGiaNhap, @DonGiaBan, @SoLuongTon... và thực hiện INSERT an toàn vào tblHang."),
    ("3. sp_CapNhatHang:", " Cập nhật thông số kỹ thuật, giá cả và số lượng tồn kho của điện thoại theo @MaHang."),
    ("4. sp_XoaHang:", " Xóa sản phẩm khỏi CSDL với kiểm tra ràng buộc toàn vẹn khóa ngoại."),
    ("5. sp_KiemTraDangNhap:", " Xác thực tài khoản nhân viên qua @TaiKhoan và @MatKhau, trả về mã nhân viên và chức vụ để phân quyền."),
    ("6. sp_TimKiemHang:", " Thủ tục tìm kiếm linh hoạt hỗ trợ đa điều kiện (tên máy, khoảng giá từ-đến, hãng sản xuất, loại máy).")
]

for name, desc in sps:
    p = tf5.add_paragraph() if tf5.paragraphs[0].text else tf5.paragraphs[0]
    p.space_after = Pt(8)
    r1 = p.add_run()
    r1.text = name + " "
    r1.font.bold = True
    r1.font.size = Pt(15)
    r1.font.color.rgb = DARK_BLUE
    r2 = p.add_run()
    r2.text = desc
    r2.font.size = Pt(14)

# --- SLIDE 6: BÁN HÀNG & NHẬP HÀNG ---
s6 = prs.slides.add_slide(blank_layout)
create_header(s6, "5. NGHIỆP VỤ BÁN HÀNG (POS) & NHẬP KHO", "Tự động hóa hoàn toàn quy trình xử lý kho hàng và tính toán thanh toán")

box6_l = s6.shapes.add_textbox(Inches(0.8), Inches(1.6), Inches(5.6), Inches(5.2))
tf6_l = box6_l.text_frame
tf6_l.word_wrap = True
p = tf6_l.paragraphs[0]
p.text = "HÓA ĐƠN BÁN HÀNG (FORM 7):"
p.font.bold = True
p.font.size = Pt(18)
p.font.color.rgb = DARK_BLUE

p = tf6_l.add_paragraph()
p.text = "• Chọn khách hàng & nhân viên lập hóa đơn.\n• Thêm sản phẩm vào giỏ hàng: Kiểm tra số lượng tồn kho trước khi bán.\n• Tự động tính Thành tiền = (SL * Đơn giá) * (1 - Giảm giá%).\n• Tự động tính Tổng tiền cả hóa đơn.\n• TỰ ĐỘNG TRỪ TỒN KHO: Sử dụng SqlTransaction đảm bảo cập nhật đồng thời bảng tblHoaDonBan, tblChiTietHDB và trừ SoLuongTon trong tblHang."
p.font.size = Pt(14)
p.space_before = Pt(8)

box6_r = s6.shapes.add_textbox(Inches(6.8), Inches(1.6), Inches(5.7), Inches(5.2))
tf6_r = box6_r.text_frame
tf6_r.word_wrap = True
p = tf6_r.paragraphs[0]
p.text = "HÓA ĐƠN NHẬP HÀNG (FORM 8):"
p.font.bold = True
p.font.size = Pt(18)
p.font.color.rgb = DARK_BLUE

p = tf6_r.add_paragraph()
p.text = "• Chọn Nhà cung cấp & nhân viên tiếp nhận kho.\n• Nhập danh sách mặt hàng, số lượng và đơn giá nhập thực tế.\n• TỰ ĐỘNG CỘNG TỒN KHO: Cập nhật tăng SoLuongTon trong kho ngay sau khi lưu phiếu nhập thành công.\n• Cập nhật lại giá nhập mới nhất cho mặt hàng."
p.font.size = Pt(14)
p.space_before = Pt(8)

# --- SLIDE 7: BÁO CÁO & XUẤT EXCEL ---
s7 = prs.slides.add_slide(blank_layout)
create_header(s7, "6. TÍNH NĂNG XUẤT BÁO CÁO & HÓA ĐƠN EXCEL", "Tích hợp thư viện Microsoft.Office.Interop.Excel định dạng chuyên nghiệp")

box7 = s7.shapes.add_textbox(Inches(0.8), Inches(1.6), Inches(11.7), Inches(5.2))
tf7 = box7.text_frame
tf7.word_wrap = True

excels = [
    ("1. Xuất Hóa đơn Bán hàng:", " Khách mua hàng có thể nhận ngay file Excel hóa đơn gồm đầy đủ: Tiêu đề cửa hàng, Mã HĐ, Tên KH, Địa chỉ, Danh sách điện thoại đã mua, Thành tiền và Lời cảm ơn."),
    ("2. Xuất Phiếu Nhập hàng:", " Xuất bảng kê chi tiết các thiết bị nhập từ nhà cung cấp kèm chữ ký người giao và người nhận."),
    ("3. Xuất Báo cáo Danh sách Sản phẩm (Form6):", " Báo cáo toàn bộ sản phẩm theo kết quả tìm kiếm (theo mức giá, hãng SX...). Có đánh số thứ tự (STT), định dạng tiền tệ VNĐ (N0), tiêu đề bôi đậm, tô màu nền bảng và tự động co giãn cột (AutoFit)."),
    ("4. Trải nghiệm người dùng mượt mà:", " Sử dụng SaveFileDialog cho phép người dùng tùy chọn nơi lưu file, thông báo thành công và tự động mở file Excel ngay sau khi xuất.")
]

for name, desc in excels:
    p = tf7.add_paragraph() if tf7.paragraphs[0].text else tf7.paragraphs[0]
    p.space_after = Pt(12)
    r1 = p.add_run()
    r1.text = name + " "
    r1.font.bold = True
    r1.font.size = Pt(15)
    r1.font.color.rgb = ACCENT_BLUE
    r2 = p.add_run()
    r2.text = desc
    r2.font.size = Pt(14)

# --- SLIDE 8: DEMO & KẾT LUẬN ---
s8 = prs.slides.add_slide(blank_layout)
bg8 = s8.shapes.add_shape(MSO_SHAPE.RECTANGLE, 0, 0, Inches(13.333), Inches(7.5))
bg8.fill.solid()
bg8.fill.fore_color.rgb = DARK_BLUE
bg8.line.fill.background()

box8 = s8.shapes.add_textbox(Inches(1.0), Inches(1.5), Inches(11.333), Inches(4.5))
tf8 = box8.text_frame
tf8.word_wrap = True

p = tf8.paragraphs[0]
p.text = "PHẦN TRÌNH DIỄN THỰC TẾ ỨNG DỤNG (DEMO)"
p.font.name = "Arial"
p.font.size = Pt(30)
p.font.bold = True
p.font.color.rgb = RGBColor(255, 204, 0)
p.alignment = PP_ALIGN.CENTER

p = tf8.add_paragraph()
p.text = "1. Đăng nhập tài khoản Quản lý (an / 123456) & Nhân viên (binh / 123456)\n2. Thêm / Sửa / Xóa điện thoại (Form1)\n3. Lập Hóa đơn bán hàng & Trừ kho tự động (Form7)\n4. Tìm kiếm nâng cao & Xuất file Excel báo cáo (Form6)"
p.font.name = "Arial"
p.font.size = Pt(18)
p.font.color.rgb = WHITE
p.space_before = Pt(25)

p = tf8.add_paragraph()
p.text = "XIN CẢM ƠN CÔ VÀ CÁC BẠN ĐÃ LẮNG NGHE!"
p.font.name = "Arial"
p.font.size = Pt(26)
p.font.bold = True
p.font.color.rgb = RGBColor(200, 220, 255)
p.alignment = PP_ALIGN.CENTER
p.space_before = Pt(40)

ppt_path = r"C:\Users\Nam3\Season1\Laptrinhtrucquan\QuanLyCuaHangDienThoai\ThuyetTrinh_BTL_Nhom4_QuanLyCuaHangDienThoai.pptx"
prs.save(ppt_path)
print("Saved Slide PPTX successfully:", ppt_path)