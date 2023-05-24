import cv2
import mediapipe as mp

# 투명도를 가져오기위해 4채널이미지
# 이미지 합성의  베이스가 4채널 이미지라서 3채널 이미지로 바꿔주기 위한 함수
# image 대상이미지(3채널)/ 대상이미지의 x,y 위치 / 가로 세로 크기 w, h / 덮어 쓸 이미지(4채널)
# 4채널 이미지에서  alpha 값을 가져오기 위해
def overlay(image, x, y, w, h, overlay_image):
    alpha = overlay_image[:, :, 3] # BGRA -> alpha값만 가져온다.
    mask_image = alpha/255 # 0~255 값 사이인데 255로 나누면 0~1사이의 mask이미지를 가진다
    # 0.0~1.0 값을 가짐 -> 1 - mask_image를 하면 1.0~0.0 으로 반전이 됨
    # 이 둘의 데이터를 더하면 0+1 = 1 1+0 = 1인 전체가 1인 alpha 값이 나온다.
    # 즉 1은 불투명한 상태 alpha 값 =1 즉 결과값도 1인 배경이 지워진 불투명한 상태
    
    for c in range(0, 3): # chanle / B(0)G(1)R(2)
        image[y-h:y+h, x-w:x+w, c] = (overlay_image[:, :, c] * mask_image) + (image[y-h:y+h,x-w:x+w, c] * (mask_image))
        #y-h:y+h 세로영역 / x-w:x+w 가로영역 / 채널 부분: C

# 얼굴을 찾고, 찾은 얼굴에 표시를 해주기 위한 변수 정의
mp_face_detection = mp.solutions.face_detection # 얼굴 검출을 위해서 face_detection 모듈 사용한다.
mp_drawing = mp.solutions.drawing_utils # 얼굴의 특징을 그리기 위한 drawing_utils 모듈 사용한다.

# 동영상 파일 열기
cap = cv2.VideoCapture(0)

# 이미지 불러오기
image_right_eye = cv2.imread("C:\\yyh\\openCV\\data\\sunglass_right.png", cv2.IMREAD_UNCHANGED) # 이미지 크기 100x100 # 투명도까지 가져오기 위해 cv2.IMREAD_UNCHANGED
image_left_eye = cv2.imread("C:\\yyh\\openCV\\data\\sunglass_left.png", cv2.IMREAD_UNCHANGED) # 100x100
image_nose = cv2.imread("C:\\yyh\\openCV\\data\\pirrot_nosw.png", cv2.IMREAD_UNCHANGED) # 300x100
image_mouse = cv2.imread("C:\\yyh\\openCV\\data\\pirrot_mouse.png",cv2.IMREAD_UNCHANGED) # 300x100


# FaceDetection 함수를 불러오고 with는 별도로 close 할 필요없이 자동으로 닫힌다
with mp_face_detection.FaceDetection(model_selection=0, min_detection_confidence=0.7) as face_detection:
    # 두가지 파라미터를 넘겨준다 첫 번째 model_selection은 mediapipe에서 FaceDetection 객체를 만드는데 0 또는 1을 받는데 0은 카메라로부터 근거리 1은 5미터이내 먼 거리를 받는다.
    # min_detection_confidence는 어느 정도 %정도되면 얼굴로 인식한다. ex)0.5는 50%
    while cap.isOpened():
        success, image = cap.read()
        if not success:
            break

        # 이미지를 RGB형식으로 변환
        image.flags.writeable = False # 이미지 다시쓰기
        image = cv2.cvtColor(image, cv2.COLOR_BGR2RGB)
        results = face_detection.process(image)

        image.flags.writeable = True
        image = cv2.cvtColor(image, cv2.COLOR_RGB2BGR)
        if results.detections:
            # 6개의 특징 : 오른쪽 눈, 왼쪽 눈, 코 끝부분, 입 중심 ,오른쪽 귀, 왼쪽 귀를 좌표를 알려준다.
            for detection in results.detections:
                mp_drawing.draw_detection(image, detection)
                print(detection) # detection 정보를 알려준다.

                # 특정 위치가져오기
                keypoints = detection.location_data.relative_keypoints
                right_eye = keypoints[0] # 오른쪽 눈
                left_eye = keypoints[1] # 왼쪽 눈
                nose_tip = keypoints[2] # 코 끝 부분
                mouse_tip = keypoints[3] # 입 부분
             

                
                h,w,c = image.shape # height, width , channel : 이미지로부터 세로, 가로 크기 가져옴
                right_eye = (int(right_eye.x * w), int(right_eye.y * h)) # 이미지 내에서 실제 좌표(x,y)
                left_eye = (int(left_eye.x * w) , int(left_eye.y * h))
                nose_tip = (int(nose_tip.x * w ), int(nose_tip.y * h))
                mouse_tip = (int(mouse_tip.x*w), int(mouse_tip.y*h))

           
                #overlay 함수 호출 overlay(image, x,y,w,h,overlay_image)
                overlay(image, *right_eye, 50,50,image_right_eye)
                overlay(image, *left_eye, 50,50,image_left_eye)
                overlay(image, *nose_tip, 150,50,image_nose)
                overlay(image, *mouse_tip, 150,50,image_mouse)
                    
              

        #작업된 image를 imshow를 통해 본다.
        cv2.imshow('cam', cv2.resize(image, None, fx=0.5, fy=0.5))

        key = cv2.waitKey(1)
        # python에서는 ord를 사용해 문자을 ASCII코드로 변환
        if key == ord('1'):
            break
        elif key == ord('2'):
            print("저장 성공")
            cv2.IMREAD_UNCHANGED
            cv2.imwrite("C:\\yyh\\openCV\\data\\cap.png",image)
       

cap.release()
cv2.destroyAllWindows()
