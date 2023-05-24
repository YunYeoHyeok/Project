var map;
var directionsService;
var directionsDisplay;

function initMap() {
    // 구글 지도 생성
    map = new google.maps.Map(document.getElementById('map'), {
        center: { lat: 37.566535, lng: 126.9779692 },
        zoom: 12
    });
    // 네비게이션 경로 생성
    // 네비게이션 서비스 생성
    directionsService = new google.maps.DirectionsService();
    // 네비게이션 경로 표시 생성
    directionsDisplay = new google.maps.DirectionsRenderer();
    directionsDisplay.setMap(map);
    directionsDisplay.setPanel(document.getElementById('directions-panel'));

    // 폼 제출 이벤트 등록
    document.getElementById('route-form').addEventListener('submit', function (event) {
        event.preventDefault();
        calculateRoute();
    });

    // 출발지와 도착지로 경로 검색
    function calculateRoute() {
        var start = document.getElementById('start').value;
        var end = document.getElementById('end').value;

        var request = {
            origin: start,
            destination: end,
            travelMode: 'DRIVING'
        };

        directionsService.route(request, function (result, status) {
            if (status == 'OK') {
                directionsDisplay.setDirections(result);

                // 예상 시간 표시
                var route = result.routes[0];
                var totalTime = 0;
                for (var i = 0; i < route.legs.length; i++) {
                    totalTime += route.legs[i].duration.value;
                }
                var hours = Math.floor(totalTime / 3600);
                var minutes = Math.floor((totalTime - (hours * 3600)) / 60);
                document.getElementById('total-time').innerHTML = hours + '시간 ' + minutes + '분';
            } else {
                alert('경로 검색에 실패하였습니다.');
            }
        });
    }
}
