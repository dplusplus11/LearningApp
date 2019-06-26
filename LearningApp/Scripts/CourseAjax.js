$(document).ready(function () {
    $('#btn-edit').click(function () {
        var courseName = $('.courseName').val();
        var intro = $('.introduction').val();
        var takeAway = $('.takeAwaySkills').val();
        var pre = $('.prerequisites').val();
        var langId = $('.languageId').val();
        var catId = $('.categoryId').val();
        var time = $('.timeToComplete').val();
        var whyLearn = $('.whyLearn').val();
        var pro = $('.proCourse').val();
        if (courseName != "" && intro != "" && takeAway != "" && pre != "" && langId != "" && catId != "" && time != "" && whyLearn != "" && pro != "") {
            $.ajax({
                url: "/api/courses/" + $(this).attr("data-course-id"),
                method: "PUT",
                dataType: "json",
                data:
                {
                    Name: courseName,
                    Introduction: intro,
                    TakeAwaySkills: takeAway,
                    Prerequisites: pre,
                    LanguageId: langId,
                    CategoryId: catId,
                    TimeToComplete: time,
                    WhyLearn: whyLearn,
                    ProCourse : pro
                },
                success: function (response) {
                    console.log("Yup.It's a success.");
                    window.location.replace('/Courses/Details/' + $('#btn-edit').attr("data-course-id"), 2000);
                    
                },
                error: function () {
                    alert("There was an error.");
                }
            });
        }
        else {
            bootbox.alert({
                message: "All fields are required.",
                callback: function () {
                    console.log('All fields are required.');
                }
            });
        }
    });

    $('#btn-upload').click(function () {
        var courseName = $('.courseName').val();
        var intro = $('.introduction').val();
        var takeAway = $('.takeAwaySkills').val();
        var pre = $('.prerequisites').val();
        var langId = $('.languageId').val();
        var catId = $('.categoryId').val();
        var time = $('.timeToComplete').val();
        var whyLearn = $('.whyLearn').val();
        var proCourse = $('.proCourse').val();
        
        if (courseName != "" && intro != "" && takeAway != "" && pre != "" && langId != "" && catId != "" && time != "" && whyLearn != "" && proCourse !="") {
            $.ajax({
                url: "/api/courses/",
                method: "POST",
                dataType: "json",
                data:
                {
                    Name: courseName,
                    Introduction: intro,
                    TakeAwaySkills: takeAway,
                    Prerequisites: pre,
                    LanguageId: langId,
                    CategoryId: catId,
                    TimeToComplete: time,
                    WhyLearn: whyLearn,
                    ProCourse : proCourse
                },
                success: function (response) {
                    console.log("Yup.It's a success.");
                    window.location.replace('/Courses');

                },
                error: function () {
                    alert("There was an error.");
                }
            });
        }
        else {
            bootbox.alert({
                message: "All fields are required.",
                callback: function () {
                    console.log('All fields are required.');
                }
            });
        }
    });


});
