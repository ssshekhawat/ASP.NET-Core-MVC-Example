(function ($) {
    function Employee() {
        var $this = this;

        function initilizeModel() {           
            $("#modal-action-employee").on('loaded.bs.modal', function (e) {               
                }).on('hidden.bs.modal', function (e) {                   
                    $(this).removeData('bs.modal');
                });            
        }       
        $this.init = function () {
            initilizeModel();
        }
    }
    $(function () {
        var self = new Employee();
        self.init();        
    })
}(jQuery))
