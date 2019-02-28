import * as React from 'react';
import { Layout, Menu, Breadcrumb, Icon } from 'antd';
import MenuItem from '../../node_modules/antd/lib/menu/MenuItem';
import { Link, RouteComponentProps } from 'react-router-dom';
import { ClientRoutes, Constants } from '../constants';
const { Header, Content, Footer, Sider } = Layout;

const SubMenu = Menu.SubMenu;

interface WrapperHeaderProps {}

interface WrapperHeaderState {
  collapsed: boolean;
}
export const wrapperHeader = (Component: React.ComponentClass<any> | React.SFC<any>,
displayName:string) => {
  class WrapperHeaderComponent extends React.Component<WrapperHeaderProps & RouteComponentProps, WrapperHeaderState> {
    state = { collapsed: true };

    onCollapse = () => {
      this.setState({ ...this.state, collapsed: !this.state.collapsed });
    };
    render() {
      return (
        <Layout style={{ minHeight: '100vh' }}>
          <Sider
            collapsible
            collapsed={this.state.collapsed}
            onCollapse={this.onCollapse}
          >
            <div className="logo" />
            <Menu theme="dark" defaultSelectedKeys={['1']} mode="inline">
               <MenuItem
                key="Home"
				onClick={() =>  {this.setState({...this.state, collapsed:true})}}
              >
                <Icon type="home" />
                <span>Home</span>
                <Link to={'/'}></Link>
              </MenuItem>

			   			   <MenuItem
                key="address"
              >
			  <Icon type="pie-chart" />
              <span>Address</span>
              <Link to={ClientRoutes.Addresses}></Link>
              </MenuItem>

							   <MenuItem
                key="call"
              >
			  <Icon type="rise" />
              <span>Call</span>
              <Link to={ClientRoutes.Calls}></Link>
              </MenuItem>

							   <MenuItem
                key="callDisposition"
              >
			  <Icon type="bars" />
              <span>CallDisposition</span>
              <Link to={ClientRoutes.CallDispositions}></Link>
              </MenuItem>

							   <MenuItem
                key="callPerson"
              >
			  <Icon type="cloud" />
              <span>CallPerson</span>
              <Link to={ClientRoutes.CallPersons}></Link>
              </MenuItem>

							   <MenuItem
                key="callStatu"
              >
			  <Icon type="code" />
              <span>CallStatus</span>
              <Link to={ClientRoutes.CallStatus}></Link>
              </MenuItem>

							   <MenuItem
                key="callType"
              >
			  <Icon type="smile" />
              <span>CallType</span>
              <Link to={ClientRoutes.CallTypes}></Link>
              </MenuItem>

							   <MenuItem
                key="note"
              >
			  <Icon type="laptop" />
              <span>Note</span>
              <Link to={ClientRoutes.Notes}></Link>
              </MenuItem>

							   <MenuItem
                key="officer"
              >
			  <Icon type="mobile" />
              <span>Officer</span>
              <Link to={ClientRoutes.Officers}></Link>
              </MenuItem>

							   <MenuItem
                key="officerCapabilities"
              >
			  <Icon type="paper-clip" />
              <span>OfficerCapabilities</span>
              <Link to={ClientRoutes.OfficerCapabilities}></Link>
              </MenuItem>

							   <MenuItem
                key="person"
              >
			  <Icon type="setting" />
              <span>Person</span>
              <Link to={ClientRoutes.People}></Link>
              </MenuItem>

							   <MenuItem
                key="personType"
              >
			  <Icon type="user" />
              <span>PersonType</span>
              <Link to={ClientRoutes.PersonTypes}></Link>
              </MenuItem>

							   <MenuItem
                key="unit"
              >
			  <Icon type="home" />
              <span>Unit</span>
              <Link to={ClientRoutes.Units}></Link>
              </MenuItem>

							   <MenuItem
                key="unitDisposition"
              >
			  <Icon type="camera" />
              <span>UnitDisposition</span>
              <Link to={ClientRoutes.UnitDispositions}></Link>
              </MenuItem>

							   <MenuItem
                key="vehicle"
              >
			  <Icon type="like" />
              <span>Vehicle</span>
              <Link to={ClientRoutes.Vehicles}></Link>
              </MenuItem>

							   <MenuItem
                key="vehicleCapabilities"
              >
			  <Icon type="bulb" />
              <span>VehicleCapabilities</span>
              <Link to={ClientRoutes.VehicleCapabilities}></Link>
              </MenuItem>

				
            </Menu>
          </Sider>
          <Layout>
            <Header style={{ background: '#fff', padding: 0 }} />
            <Content style={{ margin: '0 16px' }}>
            <h2>{displayName}</h2>
			  <div style={{ padding: 24, background: '#fff', minHeight: 360 }}>
                <Component {...this.props} />
              </div>
            </Content>
            <Footer style={{ textAlign: 'center' }}>Footer</Footer>
          </Layout>
        </Layout>
      );
    }
  }
  return WrapperHeaderComponent;
};

/*<Codenesium>
    <Hash>92b21d2dc6c516c3bca1fba84fd76c4a</Hash>
</Codenesium>*/