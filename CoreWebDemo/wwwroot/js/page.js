var pager = {
    props:
    {
        pagerData: {
            type: Object,
            default: function () {
                return {
                    isShow: true,
                    //分页大小
                    pageSize: 10,
                    //分页数
                    arrPageSize: [10, 20, 30, 40],
                    //当前页面
                    pageCurrent: 1,
                    //总分页数
                    pageCount: 1,
                    //总数
                    totalCount: 10
                }
            }
        }
    },
    //html模板内容
    template: '<div v-if="pagerData.isShow">\
				    <div class="pager" id="pager">\                        <span class="form-inline">\                            <select class="form-control" v-model="pageSize" v-on:change="showPage(pageCurrent)">\                                <option v-for="item in pagerData.arrPageSize" v-bind:value="item">{{item}}</option>\                            </select>\                        </span>\                        <span class="btn btn-default" v-on:click="showPage(1)">首页</span>\                        <span class="btn btn-default" v-on:click="showPage(pageCurrent-1)">上一页</span>\					    <span class="form-inline">\                        <input class="form-control" style="width:60px;text-align:center" type="text" v-model="pageCurrent" v-on:keyup.enter="showPage(mypageCurrent)" />\					    </span>\					    <span>共{{pagerData.pageCount}}页</span>\                        <span class="btn btn-default" v-on:click="showPage(pageCurrent+1)">下一页</span>\                        <span class="btn btn-default" v-on:click="showPage(pagerData.pageCount)">尾页</span>\					    <span>共{{pagerData.totalCount}}条数据，当前显示第{{startData}}-{{endData}}条记录</span>\                    </div>\
                </div>',
    data: function () {
        return {
            mypagesize: 10,
            mypageCurrent: 1
        }
    },
    //计算属性
    computed: {
        // 分页大小 获取的时候显示父级传入的，修改的时候修改自身的。子组件不能修改父元素的值
        pageSize: {
            get: function () {
                return this.pagerData.pageSize;
            },
            set: function (value) {
                this.mypagesize = value;
            }
        },
        pageCurrent: {
            get: function () {
                return this.pagerData.pageCurrent;
            },
            set: function (value) {
                this.mypageCurrent = value;
            }
        },
        startData: function () {
            return this.pagerData.pageSize * (this.pagerData.pageCurrent - 1) + 1;
        },
        endData: function () {
            var max = this.pagerData.pageSize * this.pagerData.pageCurrent;
            return max > this.pagerData.totalCount ? this.pagerData.totalCount : max;
        }
    },
    methods: {
        showPage: function (pageIndex) {
            if (pageIndex > 0) {
                if (pageIndex > this.pagerData.pageCount) pageIndex = this.pagerData.pageCount;
                this.$emit('show-page', { pageCurrent: pageIndex, pageSize: this.mypagesize });//事件
                                
            }
        }
    }
}