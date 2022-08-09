local transform;
local gameObject;

MessagePanel = {};
local this = MessagePanel;

--启动事件--
function MessagePanel.Awake(obj)
	gameObject = obj;
	transform = obj.transform;
	logWarn("Awake lua--->>"..gameObject.name);
	this.InitPanel();
end

--初始化面板--
function MessagePanel.InitPanel()
	this.btnClose = transform:Find("Button").gameObject;
end

--单击事件--
function MessagePanel.OnDestroy()
	logWarn("OnDestroy---->>>");
end

