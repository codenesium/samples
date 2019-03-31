import React, { Component, FormEvent } from 'react';
import axios, { AxiosError, AxiosResponse } from 'axios';
import { Constants, ApiRoutes, ClientRoutes } from '../../constants';
import * as Api from '../../api/models';
import TestAllFieldTypeMapper from '../testAllFieldType/testAllFieldTypeMapper';
import TestAllFieldTypeViewModel from '../testAllFieldType/testAllFieldTypeViewModel';
import { Form, Input, Button, Spin, Alert } from 'antd';
import { WrappedFormUtils } from 'antd/es/form/Form';
import ReactTable from 'react-table';
import * as GlobalUtilities from '../../lib/globalUtilities';

interface TestAllFieldTypeTableComponentProps {
  apiRoute: string;
  history: any;
  match: any;
}

interface TestAllFieldTypeTableComponentState {
  loading: boolean;
  loaded: boolean;
  errorOccurred: boolean;
  errorMessage: string;
  filteredRecords: Array<TestAllFieldTypeViewModel>;
}

export class TestAllFieldTypeTableComponent extends React.Component<
  TestAllFieldTypeTableComponentProps,
  TestAllFieldTypeTableComponentState
> {
  state = {
    loading: false,
    loaded: true,
    errorOccurred: false,
    errorMessage: '',
    filteredRecords: [],
  };

  handleEditClick(e: any, row: TestAllFieldTypeViewModel) {
    this.props.history.push(ClientRoutes.TestAllFieldTypes + '/edit/' + row.id);
  }

  handleDetailClick(e: any, row: TestAllFieldTypeViewModel) {
    this.props.history.push(ClientRoutes.TestAllFieldTypes + '/' + row.id);
  }

  componentDidMount() {
    this.loadRecords();
  }

  loadRecords() {
    this.setState({ ...this.state, loading: true });

    axios
      .get<Array<Api.TestAllFieldTypeClientResponseModel>>(
        this.props.apiRoute,
        {
          headers: GlobalUtilities.defaultHeaders(),
        }
      )
      .then(response => {
        GlobalUtilities.logInfo(response);

        let mapper = new TestAllFieldTypeMapper();

        let testAllFieldTypes: Array<TestAllFieldTypeViewModel> = [];

        response.data.forEach(x => {
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
      })
      .catch((error: AxiosError) => {
        GlobalUtilities.logError(error);

        if (error.response && error.response.status == 422) {
          this.setState({
            ...this.state,
            errorOccurred: false,
            errorMessage: '',
          });
        } else {
          this.setState({
            ...this.state,
            errorOccurred: true,
            errorMessage: 'Error Occurred',
          });
        }
      });
  }

  render() {
    let message: JSX.Element = <div />;
    if (this.state.errorOccurred) {
      message = <Alert message={this.state.errorMessage} type="error" />;
    }

    if (this.state.loading) {
      return <Spin size="large" />;
    } else if (this.state.errorOccurred) {
      return <Alert message={this.state.errorMessage} type="error" />;
    } else if (this.state.loaded) {
      return (
        <div>
          {message}
          <ReactTable
            data={this.state.filteredRecords}
            defaultPageSize={10}
            columns={[
              {
                Header: 'TestAllFieldTypes',
                columns: [
                  {
                    Header: 'Field Big Int',
                    accessor: 'fieldBigInt',
                    Cell: props => {
                      return <span>{String(props.original.fieldBigInt)}</span>;
                    },
                  },
                  {
                    Header: 'Field Binary',
                    accessor: 'fieldBinary',
                    Cell: props => {
                      return <span>{String(props.original.fieldBinary)}</span>;
                    },
                  },
                  {
                    Header: 'Field Bit',
                    accessor: 'fieldBit',
                    Cell: props => {
                      return <span>{String(props.original.fieldBit)}</span>;
                    },
                  },
                  {
                    Header: 'Field Char',
                    accessor: 'fieldChar',
                    Cell: props => {
                      return <span>{String(props.original.fieldChar)}</span>;
                    },
                  },
                  {
                    Header: 'Field Date',
                    accessor: 'fieldDate',
                    Cell: props => {
                      return <span>{String(props.original.fieldDate)}</span>;
                    },
                  },
                  {
                    Header: 'Field Date Time',
                    accessor: 'fieldDateTime',
                    Cell: props => {
                      return (
                        <span>{String(props.original.fieldDateTime)}</span>
                      );
                    },
                  },
                  {
                    Header: 'Field Date Time2',
                    accessor: 'fieldDateTime2',
                    Cell: props => {
                      return (
                        <span>{String(props.original.fieldDateTime2)}</span>
                      );
                    },
                  },
                  {
                    Header: 'Field Date Time Offset',
                    accessor: 'fieldDateTimeOffset',
                    Cell: props => {
                      return (
                        <span>
                          {String(props.original.fieldDateTimeOffset)}
                        </span>
                      );
                    },
                  },
                  {
                    Header: 'Field Decimal',
                    accessor: 'fieldDecimal',
                    Cell: props => {
                      return <span>{String(props.original.fieldDecimal)}</span>;
                    },
                  },
                  {
                    Header: 'Field Float',
                    accessor: 'fieldFloat',
                    Cell: props => {
                      return <span>{String(props.original.fieldFloat)}</span>;
                    },
                  },
                  {
                    Header: 'Field Image',
                    accessor: 'fieldImage',
                    Cell: props => {
                      return <span>{String(props.original.fieldImage)}</span>;
                    },
                  },
                  {
                    Header: 'Field Money',
                    accessor: 'fieldMoney',
                    Cell: props => {
                      return <span>{String(props.original.fieldMoney)}</span>;
                    },
                  },
                  {
                    Header: 'Field N Char',
                    accessor: 'fieldNChar',
                    Cell: props => {
                      return <span>{String(props.original.fieldNChar)}</span>;
                    },
                  },
                  {
                    Header: 'Field N Text',
                    accessor: 'fieldNText',
                    Cell: props => {
                      return <span>{String(props.original.fieldNText)}</span>;
                    },
                  },
                  {
                    Header: 'Field Numeric',
                    accessor: 'fieldNumeric',
                    Cell: props => {
                      return <span>{String(props.original.fieldNumeric)}</span>;
                    },
                  },
                  {
                    Header: 'Field N Varchar',
                    accessor: 'fieldNVarchar',
                    Cell: props => {
                      return (
                        <span>{String(props.original.fieldNVarchar)}</span>
                      );
                    },
                  },
                  {
                    Header: 'Field Real',
                    accessor: 'fieldReal',
                    Cell: props => {
                      return <span>{String(props.original.fieldReal)}</span>;
                    },
                  },
                  {
                    Header: 'Field Small Date Time',
                    accessor: 'fieldSmallDateTime',
                    Cell: props => {
                      return (
                        <span>{String(props.original.fieldSmallDateTime)}</span>
                      );
                    },
                  },
                  {
                    Header: 'Field Small Int',
                    accessor: 'fieldSmallInt',
                    Cell: props => {
                      return (
                        <span>{String(props.original.fieldSmallInt)}</span>
                      );
                    },
                  },
                  {
                    Header: 'Field Small Money',
                    accessor: 'fieldSmallMoney',
                    Cell: props => {
                      return (
                        <span>{String(props.original.fieldSmallMoney)}</span>
                      );
                    },
                  },
                  {
                    Header: 'Field Text',
                    accessor: 'fieldText',
                    Cell: props => {
                      return <span>{String(props.original.fieldText)}</span>;
                    },
                  },
                  {
                    Header: 'Field Time',
                    accessor: 'fieldTime',
                    Cell: props => {
                      return <span>{String(props.original.fieldTime)}</span>;
                    },
                  },
                  {
                    Header: 'Field Timestamp',
                    accessor: 'fieldTimestamp',
                    Cell: props => {
                      return (
                        <span>{String(props.original.fieldTimestamp)}</span>
                      );
                    },
                  },
                  {
                    Header: 'Field Tiny Int',
                    accessor: 'fieldTinyInt',
                    Cell: props => {
                      return <span>{String(props.original.fieldTinyInt)}</span>;
                    },
                  },
                  {
                    Header: 'Field Unique Identifier',
                    accessor: 'fieldUniqueIdentifier',
                    Cell: props => {
                      return (
                        <span>
                          {String(props.original.fieldUniqueIdentifier)}
                        </span>
                      );
                    },
                  },
                  {
                    Header: 'Field Var Binary',
                    accessor: 'fieldVarBinary',
                    Cell: props => {
                      return (
                        <span>{String(props.original.fieldVarBinary)}</span>
                      );
                    },
                  },
                  {
                    Header: 'Field Varchar',
                    accessor: 'fieldVarchar',
                    Cell: props => {
                      return <span>{String(props.original.fieldVarchar)}</span>;
                    },
                  },
                  {
                    Header: 'Field X M L',
                    accessor: 'fieldXML',
                    Cell: props => {
                      return <span>{String(props.original.fieldXML)}</span>;
                    },
                  },
                  {
                    Header: 'Actions',
                    minWidth: 150,
                    Cell: row => (
                      <div>
                        <Button
                          htmlType="button"
                          onClick={(e: any) => {
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
                          htmlType="button"
                          onClick={(e: any) => {
                            this.handleEditClick(
                              e,
                              row.original as TestAllFieldTypeViewModel
                            );
                          }}
                        >
                          <i className="fas fa-edit" />
                        </Button>
                      </div>
                    ),
                  },
                ],
              },
            ]}
          />
        </div>
      );
    } else {
      return null;
    }
  }
}


/*<Codenesium>
    <Hash>68719cf50a2aa30d85b9f85f6e2eb077</Hash>
</Codenesium>*/