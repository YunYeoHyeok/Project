import cv2
import numpy as np

title = 'img_add'
img_base = cv2.imread('C:\yyh\openCV\data\ssg_landers.png')
img_base = cv2.resize(img_base, (512,512))
rows, cols = img_base.shape[:2]

cv2.imshow(title, img_base)

img_ad = cv2.imread('C:\yyh\openCV\data\kt.png')
img_ad = cv2.resize(img_ad, (512,512))
rows, cols = img_ad.shape[:2]

# 원근 변환 전 후 4개 좌표
pts1 = np.float32([[0,0],[0,rows],[cols,0],[cols,rows]])
pts2 = np.float32([[261,268],[261,504],[380,268],[380,503]])

# 변환 전 좌표를 원본 이미지에 출력
cv2.circle(img_ad,(0,0),10,(255,0,0),-1)
cv2.circle(img_ad,(0,rows),10,(0,255,0),-1)
cv2.circle(img_ad,(cols,0),10,(255,0,255),-1)
cv2.circle(img_ad,(cols,rows),10,(0,255,255),-1)

# 원근 변환 행렬 계산
mtrx = cv2.getPerspectiveTransform(pts1,pts2)

# 원근 변환 적용
dst = cv2.warpPerspective(img_ad,mtrx,(cols, rows),cv2.BORDER_CONSTANT,0)

cv2.imshow("origin", img_ad)
cv2.imshow("perspective",dst)

# dst를 Gray영상으로 변환 dst2하고 threshold하여 mask를 만든다
dst2 = cv2.cvtColor(dst, cv2.COLOR_BGR2GRAY)
retval, mask = cv2.threshold(dst2,0, 255, cv2.THRESH_BINARY)
mask_inv = cv2.bitwise_not(mask)

cv2.imshow('mask',mask)
cv2.imshow('mask_inv',mask_inv)

# mask_inv와 배경영상을 AND연산하고 그 결과를 원근변환 영상과 더한다.
masked_base = cv2.bitwise_and(img_base,img_base,mask=mask_inv)
cv2.imshow('masked_base',masked_base)

img_added = masked_base+dst
cv2.imshow('img_added',img_added)

cv2.waitKey(0)
cv2.destroyAllWindows()
