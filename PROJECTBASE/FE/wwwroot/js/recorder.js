let audioIN = { audio: true };
//  audio is true, for recording
var mediaRecorder;
var audio;
var buttonPlayCurrent;
var fileName;
var folderName;

function startRecord(stopRecordFunction) {

    navigator.mediaDevices.getUserMedia(audioIN)

        // 'then()' method returns a Promise
        .then(function (mediaStreamObj) {

            //// Start record
            //let start = document.getElementById('btnStart');

            //// Stop record
            //let stop = document.getElementById('btnStop');

            // 2nd audio tag for play the audio
            //let playAudio = document.getElementById('adioPlay');

            // This is the main thing to recorde
            // the audio 'MediaRecorder' API
            mediaRecorder = new MediaRecorder(mediaStreamObj);
            // Pass the audio stream

            //// Start event
            //start.addEventListener('click', function (ev) {
            //    mediaRecorder.start();
            //    // console.log(mediaRecorder.state);
            //})

            //// Stop event
            //stop.addEventListener('click', function (ev) {

            //    // console.log(mediaRecorder.state);
            //});

            // If audio data available then push
            // it to the chunk array
            mediaRecorder.ondataavailable = function (ev) {
                dataArray.push(ev.data);
            }

            // Chunk array to store the audio data
            let dataArray = [];

            // Convert the audio data in to blob
            // after stopping the recording
            mediaRecorder.onstop = function (ev) {

                // blob of type mp3
                let audioData = new Blob(dataArray,
                    { 'type': 'audio/mp3;' });

                // After fill up the chunk
                // array make it empty
                dataArray = [];

                // Creating audio url with reference
                // of created blob named 'audioData'
                let audioSrc = window.URL
                    .createObjectURL(audioData);

                // Pass the audio url to the 2nd video tag
                //playAudio.src = audioSrc;

                sendFile(audioData, stopRecordFunction);

                mediaStreamObj.getTracks() // get all tracks from the MediaStream
                    .forEach(track => track.stop()); // stop each of them
            }

            mediaRecorder.start();
        })

        // If any error occurs then handles the error
        .catch(function (err) {
            console.log(err.name, err.message);
        });
}
// Access the permission for use
// the microphone
function stopRecord() {
    mediaRecorder.stop();
}

function sendFile(blob, executeFunction) {
    var fileData = new FormData();

    fileData.append("file", blob, fileName);  
    // Adding one more key to FormData object
    fileData.append('FolderName', folderName);
    //ShowLoading();
    $.ajax({
        url: '/Home/SaveRecordFiles',
        type: "POST",
        contentType: false, // Not to set any content header
        processData: false, // Not to process data
        data: fileData,
        success: function (result) {
            if (result.Status) {
                executeFunction(result.Data)
            } else {
                showErrorNotify(result.Message);
            }
        },
        error: function (err) {
            //toastr.error(err.statusText);
            //HideLoading();
            showErrorNotify(err.statusText);
        }
    });
}

function PlaySound(path) {
    
    //var audio = document.getElementById('audio');

    //if (audio.paused) {
    //    var source = document.getElementById('audioMp3Source');
    //    source.src = path.replace("~\\", "/").replace("\\", "/");
    //    audio.play()
    //} else {
    //    audio.pause();
    //}
    if (buttonPlayCurrent != null) {
        $(buttonPlayCurrent).html("<span class='fa fa-play' aria-hidden='true'></span>");
    }

    var isButtonSame = buttonPlayCurrent == event.currentTarget
    buttonPlayCurrent = event.currentTarget;

    //chưa play lần nào
    if (audio == null) {
        playAudio(path)
    } else {
        //nếu đang playing
        if (!audio.paused) {
            //nếu cùng 1 nút
            if (isButtonSame) {
                stopAudio();
            } else {
                playAudio(path)
            }
        } else {
            playAudio(path);
        }
    }

    

    $(audio).bind("ended", function () {
        $(buttonPlayCurrent).html("<span class='fa fa-play' aria-hidden='true'></span>");
        audio = null;
    });
}

function playAudio(path) {
    if (audio != null) {
        audio.pause();
    }
    $(buttonPlayCurrent).html("<span class='fa fa-pause' aria-hidden='true'></span>");
    audio = new Audio(path);
    audio.play();
}

function stopAudio() {
    $(buttonPlayCurrent).html("<span class='fa fa-play' aria-hidden='true'></span>");
    if (audio != null) {
        audio.pause();
        audio = null;
    }
}
