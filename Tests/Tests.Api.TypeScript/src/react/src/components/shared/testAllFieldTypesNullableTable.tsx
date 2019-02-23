import React, { Component, FormEvent } from 'react';
import axios from 'axios';
import { Constants, ApiRoutes, ClientRoutes } from '../../constants';
import * as Api from '../../api/models';
import TestAllFieldTypesNullableMapper from '../testAllFieldTypesNullable/testAllFieldTypesNullableMapper';
import TestAllFieldTypesNullableViewModel from '../testAllFieldTypesNullable/testAllFieldTypesNullableViewModel';
import { Form, Input, Button, Spin, Alert } from 'antd';
import { WrappedFormUtils } from 'antd/es/form/Form';
import ReactTable from 'react-table';

interface TestAllFieldTypesNullableTableComponentProps {
  id: number;
  apiRoute: string;
  history: any;
  match: any;
}

interface TestAllFieldTypesNullableTableComponentState {
  loading: boolean;
  loaded: boolean;
  errorOccurred: boolean;
  errorMessage: string;
  filteredRecords: Array<TestAllFieldTypesNullableViewModel>;
}

export class TestAllFieldTypesNullableTableComponent extends React.Component<
  TestAllFieldTypesNullableTableComponentProps,
  TestAllFieldTypesNullableTableComponentState
> {
  state = {
    loading: false,
    loaded: true,
    errorOccurred: false,
    errorMessage: '',
    filteredRecords: [],
  };

  handleEditClick(e: any, row: TestAllFieldTypesNullableViewModel) {
    this.props.history.push(
      ClientRoutes.TestAllFieldTypesNullables + '/edit/' + row.id
    );
  }

  handleDetailClick(e: any, row: TestAllFieldTypesNullableViewModel) {
    this.props.history.push(
      ClientRoutes.TestAllFieldTypesNullables + '/' + row.id
    );
  }

  componentDidMount() {
    this.setState({ ...this.state, loading: true });

    axios
      .get(this.props.apiRoute, {
        headers: {
          'Content-Type': 'application/json',
        },
      })
      .then(
        resp => {
          let response = resp.data as Array<
            Api.TestAllFieldTypesNullableClientResponseModel
          >;

          console.log(response);

          let mapper = new TestAllFieldTypesNullableMapper();

          let testAllFieldTypesNullables: Array<
            TestAllFieldTypesNullableViewModel
          > = [];

          response.forEach(x => {
            testAllFieldTypesNullables.push(
              mapper.mapApiResponseToViewModel(x)
            );
          });
          this.setState({
            ...this.state,
            filteredRecords: testAllFieldTypesNullables,
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
                Header: 'TestAllFieldTypesNullables',
                columns: [
                  {
                    Header: 'FieldBigInt',
                    accessor: 'fieldBigInt',
                    Cell: props => {
                      return <span>{String(props.original.fieldBigInt)}</span>;
                    },
                  },
                  {
                    Header: 'FieldBinary',
                    accessor: 'fieldBinary',
                    Cell: props => {
                      return <span>{String(props.original.fieldBinary)}</span>;
                    },
                  },
                  {
                    Header: 'FieldBit',
                    accessor: 'fieldBit',
                    Cell: props => {
                      return <span>{String(props.original.fieldBit)}</span>;
                    },
                  },
                  {
                    Header: 'FieldChar',
                    accessor: 'fieldChar',
                    Cell: props => {
                      return <span>{String(props.original.fieldChar)}</span>;
                    },
                  },
                  {
                    Header: 'FieldDate',
                    accessor: 'fieldDate',
                    Cell: props => {
                      return <span>{String(props.original.fieldDate)}</span>;
                    },
                  },
                  {
                    Header: 'FieldDateTime',
                    accessor: 'fieldDateTime',
                    Cell: props => {
                      return (
                        <span>{String(props.original.fieldDateTime)}</span>
                      );
                    },
                  },
                  {
                    Header: 'FieldDateTime2',
                    accessor: 'fieldDateTime2',
                    Cell: props => {
                      return (
                        <span>{String(props.original.fieldDateTime2)}</span>
                      );
                    },
                  },
                  {
                    Header: 'FieldDateTimeOffset',
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
                    Header: 'FieldDecimal',
                    accessor: 'fieldDecimal',
                    Cell: props => {
                      return <span>{String(props.original.fieldDecimal)}</span>;
                    },
                  },
                  {
                    Header: 'FieldFloat',
                    accessor: 'fieldFloat',
                    Cell: props => {
                      return <span>{String(props.original.fieldFloat)}</span>;
                    },
                  },
                  {
                    Header: 'FieldImage',
                    accessor: 'fieldImage',
                    Cell: props => {
                      return <span>{String(props.original.fieldImage)}</span>;
                    },
                  },
                  {
                    Header: 'FieldMoney',
                    accessor: 'fieldMoney',
                    Cell: props => {
                      return <span>{String(props.original.fieldMoney)}</span>;
                    },
                  },
                  {
                    Header: 'FieldNChar',
                    accessor: 'fieldNChar',
                    Cell: props => {
                      return <span>{String(props.original.fieldNChar)}</span>;
                    },
                  },
                  {
                    Header: 'FieldNText',
                    accessor: 'fieldNText',
                    Cell: props => {
                      return <span>{String(props.original.fieldNText)}</span>;
                    },
                  },
                  {
                    Header: 'FieldNumeric',
                    accessor: 'fieldNumeric',
                    Cell: props => {
                      return <span>{String(props.original.fieldNumeric)}</span>;
                    },
                  },
                  {
                    Header: 'FieldNVarchar',
                    accessor: 'fieldNVarchar',
                    Cell: props => {
                      return (
                        <span>{String(props.original.fieldNVarchar)}</span>
                      );
                    },
                  },
                  {
                    Header: 'FieldReal',
                    accessor: 'fieldReal',
                    Cell: props => {
                      return <span>{String(props.original.fieldReal)}</span>;
                    },
                  },
                  {
                    Header: 'FieldSmallDateTime',
                    accessor: 'fieldSmallDateTime',
                    Cell: props => {
                      return (
                        <span>{String(props.original.fieldSmallDateTime)}</span>
                      );
                    },
                  },
                  {
                    Header: 'FieldSmallInt',
                    accessor: 'fieldSmallInt',
                    Cell: props => {
                      return (
                        <span>{String(props.original.fieldSmallInt)}</span>
                      );
                    },
                  },
                  {
                    Header: 'FieldSmallMoney',
                    accessor: 'fieldSmallMoney',
                    Cell: props => {
                      return (
                        <span>{String(props.original.fieldSmallMoney)}</span>
                      );
                    },
                  },
                  {
                    Header: 'FieldText',
                    accessor: 'fieldText',
                    Cell: props => {
                      return <span>{String(props.original.fieldText)}</span>;
                    },
                  },
                  {
                    Header: 'FieldTime',
                    accessor: 'fieldTime',
                    Cell: props => {
                      return <span>{String(props.original.fieldTime)}</span>;
                    },
                  },
                  {
                    Header: 'FieldTimestamp',
                    accessor: 'fieldTimestamp',
                    Cell: props => {
                      return (
                        <span>{String(props.original.fieldTimestamp)}</span>
                      );
                    },
                  },
                  {
                    Header: 'FieldTinyInt',
                    accessor: 'fieldTinyInt',
                    Cell: props => {
                      return <span>{String(props.original.fieldTinyInt)}</span>;
                    },
                  },
                  {
                    Header: 'FieldUniqueIdentifier',
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
                    Header: 'FieldVarBinary',
                    accessor: 'fieldVarBinary',
                    Cell: props => {
                      return (
                        <span>{String(props.original.fieldVarBinary)}</span>
                      );
                    },
                  },
                  {
                    Header: 'FieldVarchar',
                    accessor: 'fieldVarchar',
                    Cell: props => {
                      return <span>{String(props.original.fieldVarchar)}</span>;
                    },
                  },
                  {
                    Header: 'FieldXML',
                    accessor: 'fieldXML',
                    Cell: props => {
                      return <span>{String(props.original.fieldXML)}</span>;
                    },
                  },
                  {
                    Header: 'Id',
                    accessor: 'id',
                    Cell: props => {
                      return <span>{String(props.original.id)}</span>;
                    },
                  },
                  {
                    Header: 'Actions',
                    Cell: row => (
                      <div>
                        <Button
                          type="primary"
                          onClick={(e: any) => {
                            this.handleDetailClick(
                              e,
                              row.original as TestAllFieldTypesNullableViewModel
                            );
                          }}
                        >
                          <i className="fas fa-search" />
                        </Button>
                        &nbsp;
                        <Button
                          type="primary"
                          onClick={(e: any) => {
                            this.handleEditClick(
                              e,
                              row.original as TestAllFieldTypesNullableViewModel
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
    <Hash>258ec721827bda32a2e62bddd4ac326e</Hash>
</Codenesium>*/