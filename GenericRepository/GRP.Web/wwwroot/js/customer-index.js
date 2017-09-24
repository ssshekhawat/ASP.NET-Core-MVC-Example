(function ($) {
    function Customer() {
        var $this = this;

        function initilizeModel() {
            $("#modal-action-customer").on('loaded.bs.modal', function (e) {

            }).on('hidden.bs.modal', function (e) {
                $(this).removeData('bs.modal');
            });
        }
        $this.init = function () {
            initilizeModel();
        }
    }
    $(function () {
        var self = new Customer();
        self.init();
    })
}(jQuery))
