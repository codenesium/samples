import React, { Component, ReactElement, ReactHTMLElement } from 'react';
import axios from 'axios';
import { Redirect } from 'react-router-dom';
import * as Api from '../../api/models';
import TestAllFieldTypeMapper from './testAllFieldTypeMapper';
import { Constants, ApiRoutes, ClientRoutes } from '../../constants';
import ReactTable from "react-table";
import TestAllFieldTypeViewModel from './testAllFieldTypeViewModel';
import "react-table/react-table.css";
import { Form, Button, Input, Row, Col, Alert, Spin } from 'antd';
import { WrappedFormUtils } from 'antd/es/form/Form';

interface TestAllFieldTypeSearchComponentProps
{
     form:WrappedFormUtils;
	 history:any;
	 match:any;
}

interface TestAllFieldTypeSearchComponentState
{
    records:Array<TestAllFieldTypeViewModel>;
    filteredRecords:Array<TestAllFieldTypeViewModel>;
    loading:boolean;
    loaded:boolean;
    errorOccurred:boolean;
    errorMessage:string;
    searchValue:string;
    deleteSubmitted:boolean;
    deleteSuccess:boolean;
    deleteResponse:string;
}

export default class TestAllFieldTypeSearchComponent extends React.Component<TestAllFieldTypeSearchComponentProps, TestAllFieldTypeSearchComponentState> {

    state = ({deleteSubmitted:false, deleteSuccess:false, deleteResponse:'', records:new Array<TestAllFieldTypeViewModel>(), filteredRecords:new Array<TestAllFieldTypeViewModel>(), searchValue:'', loading:false, loaded:true, errorOccurred:false, errorMessage:''});
    
    componentDidMount () {
        this.loadRecords();
    }

    handleEditClick(e:any, row:Api.TestAllFieldTypeClientResponseModel) {
         this.props.history.push(ClientRoutes.TestAllFieldTypes + '/edit/' + row.id);
    }

    handleDetailClick(e:any, row:Api.TestAllFieldTypeClientResponseModel) {
         this.props.history.push(ClientRoutes.TestAllFieldTypes + '/' + row.id);
    }

    handleCreateClick(e:any) {
        this.props.history.push(ClientRoutes.TestAllFieldTypes + '/create');
    }

    handleDeleteClick(e:any, row:Api.TestAllFieldTypeClientResponseModel) {
        axios.delete(Constants.ApiEndpoint + ApiRoutes.TestAllFieldTypes + '/' + row.id,
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
	   let searchEndpoint = Constants.ApiEndpoint + ApiRoutes.TestAllFieldTypes + '?limit=100';

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
		    let response = resp.data as Array<Api.TestAllFieldTypeClientResponseModel>;
		    let viewModels : Array<TestAllFieldTypeViewModel> = [];
			let mapper = new TestAllFieldTypeMapper();

			response.forEach(x =>
			{
				viewModels.push(mapper.mapApiResponseToViewModel(x));
			})

            this.setState({records:viewModels, filteredRecords:viewModels, loading:false, loaded:true, errorOccurred:false, errorMessage:''});

	   }, error => {
		   console.log(error);
		   this.setState({records:new Array<TestAllFieldTypeViewModel>(),filteredRecords:new Array<TestAllFieldTypeViewModel>(), loading:false, loaded:false, errorOccurred:true, errorMessage:'Error from API'});
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
                    Header: 'TestAllFieldType',
                    columns: [
					  {
                      Header: 'FieldBigInt',
                      accessor: 'fieldBigInt',
                      Cell: (props) => {
                      return <span>{String(props.original.fieldBigInt)}</span>;
                      }           
                    },  {
                      Header: 'FieldBinary',
                      accessor: 'fieldBinary',
                      Cell: (props) => {
                      return <span>{String(props.original.fieldBinary)}</span>;
                      }           
                    },  {
                      Header: 'FieldBit',
                      accessor: 'fieldBit',
                      Cell: (props) => {
                      return <span>{String(props.original.fieldBit)}</span>;
                      }           
                    },  {
                      Header: 'FieldChar',
                      accessor: 'fieldChar',
                      Cell: (props) => {
                      return <span>{String(props.original.fieldChar)}</span>;
                      }           
                    },  {
                      Header: 'FieldDate',
                      accessor: 'fieldDate',
                      Cell: (props) => {
                      return <span>{String(props.original.fieldDate)}</span>;
                      }           
                    },  {
                      Header: 'FieldDateTime',
                      accessor: 'fieldDateTime',
                      Cell: (props) => {
                      return <span>{String(props.original.fieldDateTime)}</span>;
                      }           
                    },  {
                      Header: 'FieldDateTime2',
                      accessor: 'fieldDateTime2',
                      Cell: (props) => {
                      return <span>{String(props.original.fieldDateTime2)}</span>;
                      }           
                    },  {
                      Header: 'FieldDateTimeOffset',
                      accessor: 'fieldDateTimeOffset',
                      Cell: (props) => {
                      return <span>{String(props.original.fieldDateTimeOffset)}</span>;
                      }           
                    },  {
                      Header: 'FieldDecimal',
                      accessor: 'fieldDecimal',
                      Cell: (props) => {
                      return <span>{String(props.original.fieldDecimal)}</span>;
                      }           
                    },  {
                      Header: 'FieldFloat',
                      accessor: 'fieldFloat',
                      Cell: (props) => {
                      return <span>{String(props.original.fieldFloat)}</span>;
                      }           
                    },  {
                      Header: 'FieldImage',
                      accessor: 'fieldImage',
                      Cell: (props) => {
                      return <span>{String(props.original.fieldImage)}</span>;
                      }           
                    },  {
                      Header: 'FieldMoney',
                      accessor: 'fieldMoney',
                      Cell: (props) => {
                      return <span>{String(props.original.fieldMoney)}</span>;
                      }           
                    },  {
                      Header: 'FieldNChar',
                      accessor: 'fieldNChar',
                      Cell: (props) => {
                      return <span>{String(props.original.fieldNChar)}</span>;
                      }           
                    },  {
                      Header: 'FieldNText',
                      accessor: 'fieldNText',
                      Cell: (props) => {
                      return <span>{String(props.original.fieldNText)}</span>;
                      }           
                    },  {
                      Header: 'FieldNumeric',
                      accessor: 'fieldNumeric',
                      Cell: (props) => {
                      return <span>{String(props.original.fieldNumeric)}</span>;
                      }           
                    },  {
                      Header: 'FieldNVarchar',
                      accessor: 'fieldNVarchar',
                      Cell: (props) => {
                      return <span>{String(props.original.fieldNVarchar)}</span>;
                      }           
                    },  {
                      Header: 'FieldReal',
                      accessor: 'fieldReal',
                      Cell: (props) => {
                      return <span>{String(props.original.fieldReal)}</span>;
                      }           
                    },  {
                      Header: 'FieldSmallDateTime',
                      accessor: 'fieldSmallDateTime',
                      Cell: (props) => {
                      return <span>{String(props.original.fieldSmallDateTime)}</span>;
                      }           
                    },  {
                      Header: 'FieldSmallInt',
                      accessor: 'fieldSmallInt',
                      Cell: (props) => {
                      return <span>{String(props.original.fieldSmallInt)}</span>;
                      }           
                    },  {
                      Header: 'FieldSmallMoney',
                      accessor: 'fieldSmallMoney',
                      Cell: (props) => {
                      return <span>{String(props.original.fieldSmallMoney)}</span>;
                      }           
                    },  {
                      Header: 'FieldText',
                      accessor: 'fieldText',
                      Cell: (props) => {
                      return <span>{String(props.original.fieldText)}</span>;
                      }           
                    },  {
                      Header: 'FieldTime',
                      accessor: 'fieldTime',
                      Cell: (props) => {
                      return <span>{String(props.original.fieldTime)}</span>;
                      }           
                    },  {
                      Header: 'FieldTimestamp',
                      accessor: 'fieldTimestamp',
                      Cell: (props) => {
                      return <span>{String(props.original.fieldTimestamp)}</span>;
                      }           
                    },  {
                      Header: 'FieldTinyInt',
                      accessor: 'fieldTinyInt',
                      Cell: (props) => {
                      return <span>{String(props.original.fieldTinyInt)}</span>;
                      }           
                    },  {
                      Header: 'FieldUniqueIdentifier',
                      accessor: 'fieldUniqueIdentifier',
                      Cell: (props) => {
                      return <span>{String(props.original.fieldUniqueIdentifier)}</span>;
                      }           
                    },  {
                      Header: 'FieldVarBinary',
                      accessor: 'fieldVarBinary',
                      Cell: (props) => {
                      return <span>{String(props.original.fieldVarBinary)}</span>;
                      }           
                    },  {
                      Header: 'FieldVarchar',
                      accessor: 'fieldVarchar',
                      Cell: (props) => {
                      return <span>{String(props.original.fieldVarchar)}</span>;
                      }           
                    },  {
                      Header: 'FieldXML',
                      accessor: 'fieldXML',
                      Cell: (props) => {
                      return <span>{String(props.original.fieldXML)}</span>;
                      }           
                    },  {
                      Header: 'Id',
                      accessor: 'id',
                      Cell: (props) => {
                      return <span>{String(props.original.id)}</span>;
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
                              row.original as Api.TestAllFieldTypeClientResponseModel
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
                              row.original as Api.TestAllFieldTypeClientResponseModel
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
                              row.original as Api.TestAllFieldTypeClientResponseModel
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

export const WrappedTestAllFieldTypeSearchComponent = Form.create({ name: 'TestAllFieldType Search' })(TestAllFieldTypeSearchComponent);

/*<Codenesium>
    <Hash>1bb303cca9ac2b6c33b6c0379d736d71</Hash>
</Codenesium>*/