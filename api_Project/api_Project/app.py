from flask import Flask, render_template, request
import requests  # pip install requests
from urllib.parse import urlencode, unquote
import csv
from dotenv import load_dotenv
import os
import json

load_dotenv()
myCarKey = os.environ.get("Tourist_Attractions")

app = Flask(__name__)

city_dict = {}

with open("C:/yyh/pythonOpenCV/api_Project/city.csv", mode="r", encoding="utf8") as inp:
    reader = csv.reader(inp)
    city_dict = {rows[0]: rows[1] for rows in reader}


def getWeathercontent(code):
    if code == 1:
        return "맑음"
    elif code == 2:
        return "구름조금"
    elif code == 3:
        return "구름많음"
    elif code == 4:
        return "흐림"
    elif code == 5:
        return "빗방울"


def getCar(city_id, city_data):
    url = "https://apis.data.go.kr/1360000/TourStnInfoService1/getTourStnVilageFcst1"
    queryString = "?" + urlencode(
        {
            "serviceKey": unquote(myCarKey),
            "pageNo": "1",
            "numOfRows": "1",
            "dataType": "JSON",
            "CURRENT_DATE": city_data,  # CURRENT_DATE부터 자료 호출
            "HOUR": "-20",  # CURRENT_DATE에 날짜를 입력하면 24시간 이후의 자료를 출력해줘서 -20시간을 해서 검색시간에 가깝게 출력하기 위한방법(2시간 정도의 차이)
            "COURSE_ID": city_id,
        }
    )

    response = requests.get(url + queryString)
    r_dict = json.loads(response.text)

    r_response = r_dict.get("response")
    r_body = r_response.get("body")
    r_item = r_body.get("items")
    item_list = r_item.get("item")

    for item in item_list:
        thema = item.get("thema")  # 캠핑/스포츠
        courseName = item.get("courseName")  # 포천의 명물과 함께하는 캠핑여행
        tm = item.get("tm")  # 날짜
        spotAreaName = item.get("spotAreaName")  # 포천
        spotName = item.get("spotName")  # (포천)평강식물
        th3 = item.get("th3")  # 평균 기온
        sky = item.get("sky")  # 하늘상태 (코드값) 맑음(1) , 구름조금(2), 구름많음(3), 흐림(4)
        sky_text = getWeathercontent(sky)  # 하늘상태 함수로 리턴
        pop = item.get("pop")  # 강수확률
        rhm = item.get("rhm")  # 습도
        return tm, thema, courseName, spotAreaName, spotName, th3, sky_text, pop, rhm


@app.route("/", methods=["GET", "POST"])
def index():
    if request.method == "POST":
        city_name = request.form["name"]
        city_id = city_dict.get(city_name)
        city_wdata = request.form["data"]  # city의 weather를 저장

        if city_id == None or city_wdata == "":
            return render_template("index.html")

        tm, thema, courseName, spotAreaName, spotName, th3, sky_text, pop, rhm = getCar(
            city_id, city_wdata
        )

        return render_template(
            "index2.html",  # 지역, 날짜를 입력하면 새로운 결과창을 보여줌
            thema=thema,
            courseName=courseName,
            spotAreaName=spotAreaName,
            spotName=spotName,
            th3=th3,
            sky_text=sky_text,
            pop=pop,
            rhm=rhm,
            tm=tm,
        )

    else:
        return render_template("index.html")


@app.route("/map.html")
def map():
    return render_template("map.html")


if __name__ == "__main__":
    app.run(host="0.0.0.0", port=5010)
