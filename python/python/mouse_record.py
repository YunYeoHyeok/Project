import cv2
from PIL import Image
title = 'mouse_record'
img = cv2.imread('C:\yyh\openCV\data\ssg_landers.png')
img = cv2.resize(img, (512,512))

cv2.imshow(title,img)

def onMouse(event, x, y, flags, param): # 마우스 콜백 함수
    if event == cv2.EVENT_LBUTTONDOWN: # 왼쪽 버튼 누를경우 
        print(x,y) # 파라미터 출력
        return x,y

cv2.setMouseCallback(title, onMouse)
# 마우스 콜백 함수를 GUI 윈도우에 등록

while True:
    key = cv2.waitKey(1) # esc누를시 종료
    if key == 27:
        break
cv2.destroyAllWindows()
