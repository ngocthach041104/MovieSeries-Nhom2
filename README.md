# MovieSeries
Họ và tên	MSSV	Phần trăm đóng góp
Thới Trần Ngọc Thạch	31221025597	100%
Nguyễn Ngọc Tú Trinh	31221024321	100%
Nguyễn Phụng Châu	31221024746	100%

Link github: https://github.com/ngocthach041104/MovieSeries-nhom2
1.	Kết quả thực thi.
-	Nhóm đã thực hiện thành công các phương thức CRUD.
 

-	Get Movie:
 ![image](https://github.com/user-attachments/assets/5cd3f9c6-0686-4d3f-9f5c-63c8f7ce6183)
-	Post Movie: 
 ![image](https://github.com/user-attachments/assets/fe7994ce-abfc-4bda-8edf-8ef7af352a97)
-	Get Movie by ID:
 ![image](https://github.com/user-attachments/assets/70acff5f-f5f0-499e-9c5f-68c33b435e97)
-	Put Movie:
 ![image](https://github.com/user-attachments/assets/ba71a29a-c156-45cb-a3cc-686409f3700f)
-	Delete Movie:
 ![image](https://github.com/user-attachments/assets/8f154f5b-404d-4120-9c9a-c0c6ff518922)
-	GetTopRating:
![image](https://github.com/user-attachments/assets/4c2967df-aa58-4694-819e-709befd6271a) 
 Tạm thời bị lỗi, nhóm chưa fix được lỗi trong việc xử lý các phương thức WithSp để gọi các Quy trình được lưu trữ (SP).
   
2.	Các biện luận cho các giải pháp chọn lựa.
Lý do sử dụng cấu trúc Multi-layer:
-	Phù hợp với các ứng dụng nhỏ, đơn giản.
-	Phù hợp khi bắt đầu dự án với ngân sách và thời gian phát triển hạn chế.
-	Khi vẫn đang phân tích các logic nghiệp vụ và chưa xác định được kiến trúc phù hợp thì nên chọn layer vì kiến trúc layer sẽ dễ chuyển hướng sang các kiến trúc sau này hơn.

Lợi ích khi sử dụng Multi-layer:
Một kiến trúc nhiều lớp để tổ chức ứng dụng hiệu quả và đảm bảo khả năng mở rộng. Mỗi lớp có một trách nhiệm cụ thể, thúc đẩy tính mô-đun, khả năng tái sử dụng và khả năng bảo trì trong cơ sở dữ liệu mã của chúng ta. Các lớp nhóm sẽ triển khai là:
1. Lớp lõi (CoreLayer): Xác định các thực thể cơ bản và cấu trúc được chia sẻ.
2. Lớp truy cập dữ liệu (DataAcessLayer): Quản lý quyền truy cập cơ sở dữ liệu và các hoạt động CRUD bằng mẫu lưu trữ. Nó cũng bao gồm các phương thức WithSp để gọi các Quy trình được lưu trữ (SP).
3. Lớp nghiệp vụ(BusinessLayer): Quản lý logic nghiệp vụ phức tạp và xử lý dữ liệu từ Lớp truy cập dữ liệu trước khi gửi đến Lớp dịch vụ.
4. Lớp dịch vụ(ServiceLayer): Hoạt động như một cầu nối giữa Bộ điều khiển và DAL, xử lý cả các cuộc gọi SP và không phải SP một cách không đồng bộ.
5. Lớp chung(CommonLayer): Cung cấp các hàm tiện ích và trình trợ giúp để ghi nhật ký, xác thực và xử lý lỗi.
6. Lớp API-APILayer (Bộ điều khiển): Hiển thị các điểm cuối để truy cập bên ngoài, xử lý các yêu cầu HTTP và phản hồi.

Việc chia thành nhiều layer để dễ kiểm soát, làm giảm độ phụ thuộc của từng layer trong lúc thực hiện.

