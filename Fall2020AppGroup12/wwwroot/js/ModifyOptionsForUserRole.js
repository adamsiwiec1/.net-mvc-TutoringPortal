$(document).ready(

    function () {

        $('#studentBiographyGroup').hide();
        $('#studentGraduationDateGroup').hide();
        $('#tutorBiographyGroup').hide();
        $('#tutorGraduationDateGroup').hide();
        $('#tutorRatingGroup').hide();

        $('#userRole').change(

            function () {
                var userRole = $('#userRole').val();

                if (userRole == 'Student') {
                    $('#studentBiographyGroup').show();
                    $('#studentGraduationDateGroup').show();
                    $('#tutorBiographyGroup').hide();
                    $('#tutorGraduationDateGroup').hide();
                }
                else {
                    $('#studentBiographyGroup').hide();
                    $('#studentGraduationDateGroup').hide();

                }

            }
        );

        $('#userRole').change(

            function () {
                var userRole = $('#userRole').val();



                if (userRole == 'Tutor') {
                    $('#tutorBiographyGroup').show();
                    $('#tutorGraduationDateGroup').show();
                }
                else {
                    $('#tutorBiographyGroup').hide();
                    $('#tutorGraduationDateGroup').hide();
                }

            }


        );
    }
);