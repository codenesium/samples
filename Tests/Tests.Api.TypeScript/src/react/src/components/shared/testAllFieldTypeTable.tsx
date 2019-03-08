import React, { Component, FormEvent } from 'react';
import axios from 'axios';
import { Constants, ApiRoutes, ClientRoutes } from '../../constants';
import * as Api from '../../api/models';
import TestAllFieldTypeMapper from '../testAllFieldType/testAllFieldTypeMapper';
import TestAllFieldTypeViewModel from '../testAllFieldType/testAllFieldTypeViewModel';
import { Form, Input, Button, Spin, Alert } from 'antd';
import { WrappedFormUtils } from 'antd/es/form/Form';
import ReactTable from "react-table";

interface TestAllFieldTypeTableComponentProps {
  id:number,
  apiRoute:string;
  history: any;
  match: any;
}

interface TestAllFieldTypeTableComponentState {
  loading: boolean;
  loaded: boolean;
  errorOccurred: boolean;
  errorMessage: string;
  filteredRecords : Array<TestAllFieldTypeViewModel>;
}

export class  TestAllFieldTypeTableComponent extends React.Component<
TestAllFieldTypeTableComponentProps,
TestAllFieldTypeTableComponentState
> {
  state = {
    loading: false,
    loaded: true,
    errorOccurred: false,
    errorMessage: '',
    filteredRecords:[]
  };

handleEditClick(e:any, row: TestAllFieldTypeViewModel) {
  this.props.history.push(ClientRoutes.TestAllFieldTypes + '/edit/' + row.id);
}

 handleDetailClick(e:any, row: TestAllFieldTypeViewModel) {
   this.props.history.push(ClientRoutes.TestAllFieldTypes + '/' + row.id);
 }

  componentDidMount() {
	this.loadRecords();
  }

  loadRecords() {
    this.setState({ ...this.state, loading: true });

    axios
      .get(this.props.apiRoute,
        {
          headers: {
            'Content-Type': 'application/json',
          },
        }
      )
      .then(
        resp => {
          let response = resp.data as Array<Api.TestAllFieldTypeClientResponseModel>;

          console.log(response);

          let mapper = new TestAllFieldTypeMapper();
          
          let testAllFieldTypes:Array<TestAllFieldTypeViewModel> = [];

          response.forEach(x =>
          {
              testAllFieldTypes.push(mapper.mapApiResponseToViewModel(x));
          });
          this.setState({
            ...this.state,
            filteredRecords: testAllFieldTypes,
            loading: false,
            loaded: true,
            errorOccurred: false,
            errorMessage: '',
          });
        },
        error => {
          console.log(error);
          this.setState({
            ...this.state,
            loading: false,
            loaded: false,
            errorOccurred: true,
            errorMessage: 'Error from API',
          });
        }
      );
  }

  render() {
    
	let message: JSX.Element = <div />;
    if (this.state.errorOccurred) {
      message = <Alert message={this.state.errorMessage} type="error" />;
    }

    if (this.state.loading) {
       return <Spin size="large" />;
    }
	else if (this.state.errorOccurred) {
	  return <Alert message={this.state.errorMessage} type='error' />;
	}
	 else if (this.state.loaded) {
      return (
	  <div>
		{message}
         <ReactTable 
                data={this.state.filteredRecords}
				defaultPageSize={10}
                columns={[{
                    Header: 'TestAllFieldTypes',
                    columns: [
					  {
                      Header: 'Bigint',
                      accessor: 'fieldBigInt',
                      Cell: (props) => {
                      return <span>{String(props.original.fieldBigInt)}</span>;
                      }           
                    },  {
                      Header: 'Binary',
                      accessor: 'fieldBinary',
                      Cell: (props) => {
                      return <span>{String(props.original.fieldBinary)}</span>;
                      }           
                    },  {
                      Header: 'Bit',
                      accessor: 'fieldBit',
                      Cell: (props) => {
                      return <span>{String(props.original.fieldBit)}</span>;
                      }           
                    },  {
                      Header: 'Char',
                      accessor: 'fieldChar',
                      Cell: (props) => {
                      return <span>{String(props.original.fieldChar)}</span>;
                      }           
                    },  {
                      Header: 'Date',
                      accessor: 'fieldDate',
                      Cell: (props) => {
                      return <span>{String(props.original.fieldDate)}</span>;
                      }           
                    },  {
                      Header: 'DateTime',
                      accessor: 'fieldDateTime',
                      Cell: (props) => {
                      return <span>{String(props.original.fieldDateTime)}</span>;
                      }           
                    },  {
                      Header: 'DateTime2',
                      accessor: 'fieldDateTime2',
                      Cell: (props) => {
                      return <span>{String(props.original.fieldDateTime2)}</span>;
                      }           
                    },  {
                      Header: 'DateTimeOffset',
                      accessor: 'fieldDateTimeOffset',
                      Cell: (props) => {
                      return <span>{String(props.original.fieldDateTimeOffset)}</span>;
                      }           
                    },  {
                      Header: 'Decimal',
                      accessor: 'fieldDecimal',
                      Cell: (props) => {
                      return <span>{String(props.original.fieldDecimal)}</span>;
                      }           
                    },  {
                      Header: 'Float',
                      accessor: 'fieldFloat',
                      Cell: (props) => {
                      return <span>{String(props.original.fieldFloat)}</span>;
                      }           
                    },  {
                      Header: 'Geography',
                      accessor: 'fieldGeography',
                      Cell: (props) => {
                      return <span>{String(props.original.fieldGeography)}</span>;
                      }           
                    },  {
                      Header: 'Geometry',
                      accessor: 'fieldGeometry',
                      Cell: (props) => {
                      return <span>{String(props.original.fieldGeometry)}</span>;
                      }           
                    },  {
                      Header: 'HierarchyId',
                      accessor: 'fieldHierarchyId',
                      Cell: (props) => {
                      return <span>{String(props.original.fieldHierarchyId)}</span>;
                      }           
                    },  {
                      Header: 'Image',
                      accessor: 'fieldImage',
                      Cell: (props) => {
                      return <span>{String(props.original.fieldImage)}</span>;
                      }           
                    },  {
                      Header: 'Money',
                      accessor: 'fieldMoney',
                      Cell: (props) => {
                      return <span>{String(props.original.fieldMoney)}</span>;
                      }           
                    },  {
                      Header: 'NChar',
                      accessor: 'fieldNChar',
                      Cell: (props) => {
                      return <span>{String(props.original.fieldNChar)}</span>;
                      }           
                    },  {
                      Header: 'NText',
                      accessor: 'fieldNText',
                      Cell: (props) => {
                      return <span>{String(props.original.fieldNText)}</span>;
                      }           
                    },  {
                      Header: 'Numeric',
                      accessor: 'fieldNumeric',
                      Cell: (props) => {
                      return <span>{String(props.original.fieldNumeric)}</span>;
                      }           
                    },  {
                      Header: 'NVarchar',
                      accessor: 'fieldNVarchar',
                      Cell: (props) => {
                      return <span>{String(props.original.fieldNVarchar)}</span>;
                      }           
                    },  {
                      Header: 'Real',
                      accessor: 'fieldReal',
                      Cell: (props) => {
                      return <span>{String(props.original.fieldReal)}</span>;
                      }           
                    },  {
                      Header: 'SmallDateTime',
                      accessor: 'fieldSmallDateTime',
                      Cell: (props) => {
                      return <span>{String(props.original.fieldSmallDateTime)}</span>;
                      }           
                    },  {
                      Header: 'SmallInt',
                      accessor: 'fieldSmallInt',
                      Cell: (props) => {
                      return <span>{String(props.original.fieldSmallInt)}</span>;
                      }           
                    },  {
                      Header: 'SmallMoney',
                      accessor: 'fieldSmallMoney',
                      Cell: (props) => {
                      return <span>{String(props.original.fieldSmallMoney)}</span>;
                      }           
                    },  {
                      Header: 'Text',
                      accessor: 'fieldText',
                      Cell: (props) => {
                      return <span>{String(props.original.fieldText)}</span>;
                      }           
                    },  {
                      Header: 'Time',
                      accessor: 'fieldTime',
                      Cell: (props) => {
                      return <span>{String(props.original.fieldTime)}</span>;
                      }           
                    },  {
                      Header: 'Timestamp',
                      accessor: 'fieldTimestamp',
                      Cell: (props) => {
                      return <span>{String(props.original.fieldTimestamp)}</span>;
                      }           
                    },  {
                      Header: 'TinyInt',
                      accessor: 'fieldTinyInt',
                      Cell: (props) => {
                      return <span>{String(props.original.fieldTinyInt)}</span>;
                      }           
                    },  {
                      Header: 'UniqueIdentifier',
                      accessor: 'fieldUniqueIdentifier',
                      Cell: (props) => {
                      return <span>{String(props.original.fieldUniqueIdentifier)}</span>;
                      }           
                    },  {
                      Header: 'VarBinary',
                      accessor: 'fieldVarBinary',
                      Cell: (props) => {
                      return <span>{String(props.original.fieldVarBinary)}</span>;
                      }           
                    },  {
                      Header: 'Varchar',
                      accessor: 'fieldVarchar',
                      Cell: (props) => {
                      return <span>{String(props.original.fieldVarchar)}</span>;
                      }           
                    },  {
                      Header: 'Variant',
                      accessor: 'fieldVariant',
                      Cell: (props) => {
                      return <span>{String(props.original.fieldVariant)}</span>;
                      }           
                    },  {
                      Header: 'XML',
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
					    minWidth:150,
                        Cell: row => (<div>
					    <Button
                          type="primary" 
                          onClick={(e:any) => {
                            this.handleDetailClick(
                              e,
                              row.original as TestAllFieldTypeViewModel
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
                              row.original as TestAllFieldTypeViewModel
                            );
                          }}
                        >
                          <i className="fas fa-edit" />
                        </Button>
                        </div>)
                    }],
                    
                  }]} />
			</div>
      );
    } else {
      return null;
    }
  }
}

/*<Codenesium>
    <Hash>508731b95fbc3fb593736d656cb645da</Hash>
</Codenesium>*/