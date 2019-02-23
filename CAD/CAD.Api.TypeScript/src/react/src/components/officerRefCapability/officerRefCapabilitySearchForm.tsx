import React, { Component, ReactElement, ReactHTMLElement } from 'react';
import axios from 'axios';
import { Redirect } from 'react-router-dom';
import * as Api from '../../api/models';
import OfficerRefCapabilityMapper from './officerRefCapabilityMapper';
import { Constants, ApiRoutes, ClientRoutes } from '../../constants';
import ReactTable from "react-table";
import OfficerRefCapabilityViewModel from './officerRefCapabilityViewModel';
import "react-table/react-table.css";
import { Form, Button, Input, Row, Col, Alert, Spin } from 'antd';
import { WrappedFormUtils } from 'antd/es/form/Form';

interface OfficerRefCapabilitySearchComponentProps
{
     form:WrappedFormUtils;
	 history:any;
	 match:any;
}

interface OfficerRefCapabilitySearchComponentState
{
    records:Array<OfficerRefCapabilityViewModel>;
    filteredRecords:Array<OfficerRefCapabilityViewModel>;
    loading:boolean;
    loaded:boolean;
    errorOccurred:boolean;
    errorMessage:string;
    searchValue:string;
    deleteSubmitted:boolean;
    deleteSuccess:boolean;
    deleteResponse:string;
}

export default class OfficerRefCapabilitySearchComponent extends React.Component<OfficerRefCapabilitySearchComponentProps, OfficerRefCapabilitySearchComponentState> {

    state = ({deleteSubmitted:false, deleteSuccess:false, deleteResponse:'', records:new Array<OfficerRefCapabilityViewModel>(), filteredRecords:new Array<OfficerRefCapabilityViewModel>(), searchValue:'', loading:false, loaded:true, errorOccurred:false, errorMessage:''});
    
    componentDidMount () {
        this.loadRecords();
    }

    handleEditClick(e:any, row:OfficerRefCapabilityViewModel) {
         this.props.history.push(ClientRoutes.OfficerRefCapabilities + '/edit/' + row.id);
    }

    handleDetailClick(e:any, row:OfficerRefCapabilityViewModel) {
         this.props.history.push(ClientRoutes.OfficerRefCapabilities + '/' + row.id);
    }

    handleCreateClick(e:any) {
        this.props.history.push(ClientRoutes.OfficerRefCapabilities + '/create');
    }

    handleDeleteClick(e:any, row:Api.OfficerRefCapabilityClientResponseModel) {
        axios.delete(Constants.ApiEndpoint + ApiRoutes.OfficerRefCapabilities + '/' + row.id,
        {
            headers: {
                'Content-Type': 'application/json',
            }
        })
        .then(resp => {
            this.setState({...this.state, deleteResponse:'Record deleted', deleteSuccess:true, deleteSubmitted:true});
            this.loadRecords(this.state.searchValue);
        }, error => {
            console.log(error);
            this.setState({...this.state, deleteResponse:'Error deleting record', deleteSuccess:false, deleteSubmitted:true});
        })
    }

   handleSearchChanged(e:React.FormEvent<HTMLInputElement>) {
		this.loadRecords(e.currentTarget.value);
   }
   
   loadRecords(query:string = '') {
	   this.setState({...this.state, searchValue:query});
	   let searchEndpoint = Constants.ApiEndpoint + ApiRoutes.OfficerRefCapabilities + '?limit=100';

	   if(query)
	   {
		   searchEndpoint += '&query=' +  query;
	   }

	   axios.get(searchEndpoint,
	   {
		   headers: {
			   'Content-Type': 'application/json',
		   }
	   })
	   .then(resp => {
		    let response = resp.data as Array<Api.OfficerRefCapabilityClientResponseModel>;
		    let viewModels : Array<OfficerRefCapabilityViewModel> = [];
			let mapper = new OfficerRefCapabilityMapper();

			response.forEach(x =>
			{
				viewModels.push(mapper.mapApiResponseToViewModel(x));
			})

            this.setState({records:viewModels, filteredRecords:viewModels, loading:false, loaded:true, errorOccurred:false, errorMessage:''});

	   }, error => {
		   console.log(error);
		   this.setState({records:new Array<OfficerRefCapabilityViewModel>(), filteredRecords:new Array<OfficerRefCapabilityViewModel>(), loading:false, loaded:true, errorOccurred:true, errorMessage:'Error from API'});
	   })
    }

    filterGrid() {

    }
    
    render () {
        if(this.state.loading) {
            return <Spin size="large" />;
        } 
		else if(this.state.errorOccurred) {
            return <Alert message={this.state.errorMessage} type="error" />
        }
        else if(this.state.loaded) {

            let errorResponse:JSX.Element = <span></span>;

            if (this.state.deleteSubmitted) {
				if (this.state.deleteSuccess) {
				  errorResponse = (
					<Alert message={this.state.deleteResponse} type="success" style={{marginBottom:"25px"}} />
				  );
				} else {
				  errorResponse = (
					<Alert message={this.state.deleteResponse} type="error" style={{marginBottom:"25px"}} />
				  );
				}
			}
            
			return (
            <div>
            {errorResponse}
            <Row>
				<Col span={8}></Col>
				<Col span={8}>   
				   <Input 
					placeholder={"Search"} 
					id={"search"} 
					onChange={(e:any) => {
					  this.handleSearchChanged(e)
				   }}/>
				</Col>
				<Col span={8}>  
				  <Button 
				  style={{'float':'right'}}
				  type="primary" 
				  onClick={(e:any) => {
                        this.handleCreateClick(e)
						}}
				  >
				  +
				  </Button>
				</Col>
			</Row>
			<br />
			<br />
            <ReactTable 
                data={this.state.filteredRecords}
                columns={[{
                    Header: 'OfficerRefCapabilities',
                    columns: [
					  {
                      Header: 'CapabilityId',
                      accessor: 'capabilityId',
                      Cell: (props) => {
                        return <a href='' onClick={(e) => { e.preventDefault(); this.props.history.push(ClientRoutes.OfficerCapabilities + '/' + props.original.capabilityId); }}>
                          {String(
                            props.original.capabilityIdNavigation.toDisplay()
                          )}
                        </a>
                      }           
                    },  {
                      Header: 'OfficerId',
                      accessor: 'officerId',
                      Cell: (props) => {
                        return <a href='' onClick={(e) => { e.preventDefault(); this.props.history.push(ClientRoutes.Officers + '/' + props.original.officerId); }}>
                          {String(
                            props.original.officerIdNavigation.toDisplay()
                          )}
                        </a>
                      }           
                    },
                    {
                        Header: 'Actions',
                        Cell: row => (<div>
					    <Button
                          type="primary" 
                          onClick={(e:any) => {
                            this.handleDetailClick(
                              e,
                              row.original as OfficerRefCapabilityViewModel
                            );
                          }}
                        >
                          <i className="fas fa-search" />
                        </Button>
                        &nbsp;
                        <Button
                          type="primary" 
                          onClick={(e:any) => {
                            this.handleEditClick(
                              e,
                              row.original as OfficerRefCapabilityViewModel
                            );
                          }}
                        >
                          <i className="fas fa-edit" />
                        </Button>
                        &nbsp;
                        <Button
                          type="danger" 
                          onClick={(e:any) => {
                            this.handleDeleteClick(
                              e,
                              row.original as OfficerRefCapabilityViewModel
                            );
                          }}
                        >
                          <i className="far fa-trash-alt" />
                        </Button>

                        </div>)
                    }],
                    
                  }]} />
                  </div>);
        } 
		else {
		  return null;
		}
    }
}

export const WrappedOfficerRefCapabilitySearchComponent = Form.create({ name: 'OfficerRefCapability Search' })(OfficerRefCapabilitySearchComponent);

/*<Codenesium>
    <Hash>1647c35c570ab92cae8bd6374d739198</Hash>
</Codenesium>*/